using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skull : MonoBehaviour
{

    public Animator animator;
    
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(!animator.GetBool("isHit")){ 
            animator.SetBool("isHit", true); 
        }
    }

    public void stopAnim(){
        animator.SetBool("isHit", false);
    }
}
