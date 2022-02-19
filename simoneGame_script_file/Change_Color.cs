using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Color : MonoBehaviour
{
   
   private static Color color;

   public static void setSquareColor(GameObject square){
        if(square){
        SpriteRenderer sprite_renderer_square=square.GetComponent<SpriteRenderer>();
        float square_r=sprite_renderer_square.color.r;
        float square_b=sprite_renderer_square.color.b;
        float square_g=sprite_renderer_square.color.g;
        float square_a=sprite_renderer_square.color.a;
        color=new Color(square_r,square_b,square_g,square_a);
       }
     }

   public static void Unhighlight_Box(GameObject square){
       if(square){
        setSquareColor(square);
        square.GetComponent<SpriteRenderer>().color=new Color(color.r,color.b,color.g,0.5f);
      }
    }
    
   public static void Highlight_Box(GameObject square){
       if(square){
         setSquareColor(square);
         square.GetComponent<SpriteRenderer>().color=new Color(color.r,color.b,color.g,1f);
       }
    }


   
    
}
