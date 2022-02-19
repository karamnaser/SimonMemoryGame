using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Resulution : MonoBehaviour
{
    public  static RectTransform rect_transform;  
    public  static int screen_width,screen_hight;  

   public static void init_rectatngletransform()
    {
       rect_transform=GameObject.Find("Main Camera").GetComponent<RectTransform>();
       screen_width=Screen.width;
       screen_hight=Screen.height;
    }


   public static void set_transform_x(int pixels){
      rect_transform.anchoredPosition=new Vector2(rect_transform.anchoredPosition.x-pixels,rect_transform.anchoredPosition.y);
   }

   public static void set_screen_resulution(int pixels){//pixels contain numbr of pixels to add to x axise
      if(Input.deviceOrientation == DeviceOrientation.Portrait){
         init_rectatngletransform();
         setScreenSize(40f);
         if(screen_width<=1440 && screen_hight<=2960){
            set_transform_x(pixels);
         }
      }
   }

   public static void set_transform_y(int pixels){
      rect_transform.anchoredPosition=new Vector2(rect_transform.anchoredPosition.x,rect_transform.anchoredPosition.y-pixels);
   }

   public static void setScreenSize(float pixels){
      GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize=pixels;
    
   }
}
