using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxyd : MonoBehaviour
{
    [SerializeField] GameObject targetGameObject; 
    public Animator animator;
    Image spr;
    [SerializeField] Sprite sprit;
    public GameObject parenti; 

    void Start()
    {
        
    }


    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col){

            spr = GetComponent<Image>();
            spr.sprite = sprit;
        if(!animator.GetBool("isHit")){        
            // Debug.Log("Hi");
            animator.SetBool("isHit", true);  
            if(targetGameObject.GetComponent<GameSettings>().activeOxydes[0] >=0){
                if(targetGameObject.GetComponent<GameSettings>().activeOxydes[1] >=0){
                    Debug.Log("sfaffa");
                }
                else{
                    targetGameObject.GetComponent<GameSettings>().activeOxydes[1] = targetGameObject.GetComponent<GameSettings>().activeOxydes[0];
                }

            }     
            else{

            }          
        }
        else{
            animator.SetBool("isHit", false);      
            
        }

        
    }

    public void ena(){
        spr.color = new Color32(255,255,255,0);
    }

    public void abl(){
        spr.color = new Color32(255,255,255,255);
    }
}
