using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skull : MonoBehaviour
{

    public Animator animator;

    private Collision2D colli;
    
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(!animator.GetBool("isHit")){ 
            animator.SetBool("isHit", true); 
        }
        Debug.Log("HIIII");
        if(!col.gameObject.GetComponent<Animator>().GetBool("shattered"))
        {
            col.gameObject.GetComponent<Animator>().SetBool("shattered", true);
            col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            colli = col;
        }
        
        
    }

    public void stopAnim(){
        animator.SetBool("isHit", false);
        colli.gameObject.GetComponent<Player>().isDead = true;
        
    }
    
}
