using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Main : MonoBehaviour
{ 
    GameObject start_button,restart_button,quit_button; 
    GameObject red_square;
    GameObject blue_square;
    GameObject green_square;
    GameObject yellow_square;
    GameObject[] squares;
    RaycastHit2D hit;
    int[] random_picked_squares_index;
    int j=0;
    int i;
    int score=0;
    int counter=0;
    bool gameover=false;
    bool game_start=false;
    bool turn_off_coratine=false;
    bool coratine_on=false;
    bool scene_is_loaded=false;


    // Start is called before the first frame update
    void Start()
    {  
         initialise_parameters();

         foreach(GameObject square in squares){
            Change_Color.Unhighlight_Box(square);
         }
    }


  void Update(){
    if(Input.GetMouseButtonDown(0) && counter==4 && j!=4){
         game_functions.On_mouseDown(hit,new Action<GameObject,int>(do_squares_match),j,gameover);
    }

    if(Input.GetMouseButtonUp(0)){
         game_functions.On_mouseUp();
    }

    if(gameover){
       asyncLoadScene("OnLoseSceen");
    }    

    if(game_start){
        if(counter!=4){
           Activatepattern();
        }
    }
 
  }
  
     
    void initialise_parameters(){
         Action<GameObject> startGameListener=StartGame;
         random_picked_squares_index=new int[4];
         start_button=GameObject.Find("play_button");
    
         game_functions.addListenerToButton(start_button,startGameListener,1);
         
         red_square=GameObject.Find("red_Square");
         blue_square=GameObject.Find("blue_square");
         green_square=GameObject.FindGameObjectsWithTag("green_square")[0];
         yellow_square=GameObject.FindGameObjectsWithTag("yellow_square")[0];
         
         squares=new GameObject[4];
         squares[0]=red_square;
         squares[1]=blue_square;
         squares[2]=green_square;
         squares[3]=yellow_square;
    }


     
   
     void Activatepattern(){
       if(!coratine_on && !turn_off_coratine){
         get_random_number(4);
         StartCoroutine("WaitAndHighlight_Box");
       }
       if(coratine_on && turn_off_coratine){
         StopCoroutine("WaitAndHighlight_Box");
         turn_off_coratine=false;
         coratine_on=false;
         counter+=1;
       }
  
     }


     

     private IEnumerator WaitAndHighlight_Box(){
        coratine_on=true;
        
        yield return new WaitForSeconds(1);
        Change_Color.Highlight_Box(squares[i]);
        yield return new WaitForSeconds(1);
        Change_Color.Unhighlight_Box(squares[i]);
        turn_off_coratine=true;
     }



    void asyncLoadScene(string sceen_name){
       if(!scene_is_loaded){
          StartCoroutine("AsynchronicLoadSceneFunc",sceen_name);
       }
       else{
          StopCoroutine("AsynchronicLoadSceneFunc");
       }
    }    

    IEnumerator AsynchronicLoadSceneFunc(string sceen_name){
        AsyncOperation asyncLoad=SceneManager.LoadSceneAsync(sceen_name);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        scene_is_loaded=true;
    }
    
   


   
      void get_random_number(int range){
        i=new Random().Next(range);
        random_picked_squares_index[counter]=i;
     }

     void StartGame(GameObject start_button){
        game_functions.desableButoon(start_button);
        game_functions.changeText("play_button_text","0");
        game_start= true;
   }


     void checkWinCondition(int counter){
       Debug.Log("im inside checkwin condition and j="+j);
       if(counter==4){
         Debug.Log("you won");
          score+=1;
          game_functions.changeText("play_button_text",""+score);
          nextLevel();      
       }
     }  

   void do_squares_match(GameObject square, int index){
         
         int correct_square_index=random_picked_squares_index[index];
         if(squares[correct_square_index]==square){
            j+=1;
            checkWinCondition(j);
         }
         else{
           gameover=true;
           game_start=false;
         }
     
   }


  void nextLevel(){
    gameover=false;
    game_start=true;
    j=0;
    counter=0;
  }
    
}








   