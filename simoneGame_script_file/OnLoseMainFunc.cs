using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class OnLoseMainFunc : MonoBehaviour
{
    GameObject restart_button;
    GameObject quit_button;   
    bool scene_is_loaded=false;

    // Start is called before the first frame update
    void Start()
    {
        initiate_params();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initiate_params(){
       restart_button=GameObject.Find("replay_button");
       quit_button=GameObject.Find("quit_game");

       restart_button.GetComponent<Button>().onClick.AddListener(LoadScreen);
       quit_button.GetComponent<Button>().onClick.AddListener(quitGame);
    }    
  

    void LoadScreen(){
      if(!scene_is_loaded){
        StartCoroutine("asyncLoadScreen","MainSceen");
      }
      else{
        StopCoroutine("asyncLoadScreen");
      }
    }

    IEnumerator asyncLoadScreen(string sceen_name){
       AsyncOperation asyncload=SceneManager.LoadSceneAsync(sceen_name);
       while (!asyncload.isDone)
        {
            yield return null;
        }
        scene_is_loaded=true;
    }

   void quitGame(){
        Application.Quit();
  }
}
