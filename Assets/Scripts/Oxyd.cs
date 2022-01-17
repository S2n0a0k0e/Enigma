using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxyd : MonoBehaviour
{
    public Animator animator;
    Image spr;
    [SerializeField] Sprite sprit;
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
        }
        else{
            animator.SetBool("isHit", false);           
        }

        
    }
}
