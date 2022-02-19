using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Random = System.Random;


public class game_functions : MonoBehaviour
{    
   static GameObject hitted_square; 
   
   public static void desableButoon(GameObject button){
       button.GetComponent<Button>().enabled=false;
    } 
   public static void changeText(string gameobjextTextName,string my_text){
       GameObject.Find(gameobjextTextName).GetComponent<Text>().text=my_text;
    }

   public static void addListenerToButton(GameObject button,Action<GameObject> func,int argumentnumbers){
         void activateAction(){
            if(argumentnumbers!=0){
              func(button);
            }
            else{
              func(null);
            }
         }
         button.GetComponent<Button>().onClick.AddListener(activateAction);
          
     }

    public static void On_mouseUp(){
         if (hitted_square != null){
          Change_Color.Unhighlight_Box(hitted_square);
         }
    }
    
    public static void On_mouseDown(RaycastHit2D hit,Action<GameObject,int> do_squares_match, int counter,bool gameover){
         if(!gameover){
             Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             Vector2 mousepos2D = new Vector2(mousepos.x, mousepos.y);
             hit = Physics2D.Raycast(mousepos2D, Vector2.zero);
             if (hit.collider != null){
                hitted_square=hit.collider.gameObject;
                Change_Color.Highlight_Box(hit.collider.gameObject);
                do_squares_match(hit.collider.gameObject,counter);
             }
          }
    }

 }