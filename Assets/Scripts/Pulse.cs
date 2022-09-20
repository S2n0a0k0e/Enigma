using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public Animator animator;
    
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(!animator.GetBool("isHit") && col.gameObject.tag != "UnmovableBlock"){ 
            animator.SetBool("isHit", true); 
        }
    }

    public void stopAnim(){
        animator.SetBool("isHit", false);
    }
}
