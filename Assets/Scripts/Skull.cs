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
        Debug.Log("HIIII");
        col.gameObject.GetComponent<Animator>().SetBool("shattered", true);
        col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        col.gameObject.GetComponent<Player>().isDead = true;
    }

    public void stopAnim(){
        animator.SetBool("isHit", false);
    }
}
