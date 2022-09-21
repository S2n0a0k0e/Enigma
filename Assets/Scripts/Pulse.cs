using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public Animator animator;
    
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
        if(!animator.GetBool("isHit") && col.gameObject.tag != "UnmovableBlock"){ 
            animator.SetBool("isHit", true); 
        }

        
        if( rb.velocity.x < 0)
        {
            rb.velocity = rb.velocity + new Vector2(-4f, 0f);
        }
        if( rb.velocity.x > 0)
        {
            rb.velocity = rb.velocity + new Vector2(4f, 0f);
        }
        if( rb.velocity.y < 0)
        {
            rb.velocity = rb.velocity + new Vector2(0f, -4f);
        }
        if( rb.velocity.y > 0)
        {
            rb.velocity = rb.velocity + new Vector2(0f, 4f);
        }
        // if(Input.GetAxis("Mouse X")<0){
        //     rb.velocity = rb.velocity + new Vector2((-mouseX1), 0f);
            
        // }
        // if(Input.GetAxis("Mouse X")>0){
        //     rb.velocity = rb.velocity + new Vector2(mouseX1, 0f);
            
        // }
        // if(Input.GetAxis("Mouse Y")<0){
        //     rb.velocity = rb.velocity + new Vector2(0f, (-mouseY1));
            
        // }
        // if(Input.GetAxis("Mouse Y")>0){
        //     rb.velocity = rb.velocity + new Vector2(0f, (mouseY1));
            
        // }
    }

    public void stopAnim(){
        animator.SetBool("isHit", false);
    }
}
