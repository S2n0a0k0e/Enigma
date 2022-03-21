using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeditationHollow : MonoBehaviour
{
    float plX;
    float plY;
    float hollowX;
    float hollowY;

    float distanceX;
    float distanceY;
    float distance;
    void OnTriggerStay2D(Collider2D col){
        
            plX = col.gameObject.transform.position.x;
            plY = col.gameObject.transform.position.y;
            hollowX = this.gameObject.transform.position.x;
            hollowY = this.gameObject.transform.position.y;
            distanceX = plX - hollowX;
            distanceY = plY - hollowY;
            Player plScript = col.gameObject.GetComponent<Player>();
            distance = Mathf.Sqrt(distanceX*distanceX + distanceY*distanceY);
            if(distance <= 0.4f){
                plScript.rb.velocity -= new Vector2(distanceX*3f, distanceY*3f);
        
            }
            // Debug.Log(distance);
            if(distance <= 0.2f){
                col.gameObject.GetComponent<BallInHollow>().inHole = true;
            }
            else{
                col.gameObject.GetComponent<BallInHollow>().inHole = false;
            }
        
    }


}
