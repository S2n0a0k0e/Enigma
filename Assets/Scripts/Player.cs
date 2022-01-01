using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float xVelocity = 0f;
    public float yVelocity = 0f;

    public float mouseX1 = 0f;
    public float mouseX2 = 0f;
    public float deltaX = 0f;

    public float mouseY1 = 0f;
    public float mouseY2 = 0f;
    public float deltaY = 0f;
    public Rigidbody2D rb;
    bool detectedCollision = false;
    

    // Start is called before the first frame update
    void Update ()
    {
        MoveMouse ();
        // VelocityChanger ();
        detectedCollision = false;
    }

    void MoveMouse () 
    {
        OnGUI ();
        if(Input.GetAxis("Mouse X")<0){
            rb.velocity = rb.velocity + new Vector2((-deltaX), 0f);
            
        }
        if(Input.GetAxis("Mouse X")>0){
            rb.velocity = rb.velocity + new Vector2(deltaX, 0f);
            
        }
        if(Input.GetAxis("Mouse Y")<0){
            rb.velocity = rb.velocity + new Vector2(0f, (-deltaY));
            
        }
        if(Input.GetAxis("Mouse Y")>0){
            rb.velocity = rb.velocity + new Vector2(0f, (deltaY));
            
        }
    }

    void VelocityChanger ()
    {
        float changeVelocity = 0.01f;
        if(rb.velocity.x > 0) 
        {
            rb.velocity = rb.velocity + new Vector2(-changeVelocity, 0f);
        }
        if(rb.velocity.x < 0) 
        {
            rb.velocity = rb.velocity + new Vector2(changeVelocity, 0f);
        }
        if(rb.velocity.y > 0) 
        {
            rb.velocity = rb.velocity + new Vector2(0f, -changeVelocity);
        }
        if(rb.velocity.y < 0) 
        {
            rb.velocity = rb.velocity + new Vector2(0f, changeVelocity);
        }
    }
    
    void OnGUI()
    {
        
            Event e = Event.current;
            mouseX1 = Input.mousePosition.x;
            mouseY1 = Input.mousePosition.y;
            deltaY = mouseY1 - mouseY2;
            deltaX = mouseX1 - mouseX2;
            if(deltaX < 0){
                deltaX *= -1;
            }
            if(deltaY < 0){
                deltaY *= -1;
            }
            if(deltaX != 0){
                deltaX = Mathf.Log(deltaX);
            }
            if(deltaY != 0){
                deltaY = Mathf.Log(deltaY);
            }
            deltaX /= 20;
            deltaY /= 20;
            
            // Debug.Log(deltaX);
            // Debug.Log(deltaY);
            mouseX2 = mouseX1;
            mouseY2 = mouseY1;
            
    }
    
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "UnmovableBlock" && detectedCollision == false)
        {
            // float xVel;
            // float yVel;
            
            //  if(col.transform.position.x + 0.5f < transform.position.x){
            //     if(col.transform.position.y + 0.5f < transform.position.y)
            //     {
            //         // rb.position = rb.position * new Vector2(1f, 0f);
            //         // rb.position = rb.position + new Vector2(0f,col.transform.position.y + 0.8f);
            //         if(rb.velocity.y <= 0){
            //             yVel = rb.velocity.y;
            //             if(yVel <= 0)
            //             {
            //                 yVel *= -1;
            //             }
            //             rb.velocity =new Vector2(rb.velocity.x,yVel);
            //         }
            //         if(rb.velocity.x <= 0){
            //             xVel = rb.velocity.x;
            //             if(xVel <= 0)
            //             {
            //                 xVel *= -1;
            //             }
            //             rb.velocity =new Vector2(xVel, rb.velocity.y);
            //         }
            //         // rb.velocity = new Vector2(-rb.velocity.y,-rb.velocity.x);
            //         // rb.velocity = new Vector2(0f, 0f);
            //         return;
            //     }
            //     else if(col.transform.position.y + 0.5f > transform.position.y && col.transform.position.y - 0.5f < transform.position.y)
            //     {
            //         rb.position = rb.position * new Vector2(0f, 1f);
            //         rb.position = rb.position + new Vector2(col.transform.position.x + 0.8f, 0f); 
            //         xVel = rb.velocity.x;
            //         xVel *= -1;
            //         rb.velocity =new Vector2(xVel, rb.velocity.y);
            //         // rb.velocity = rb.velocity * (new Vector2(-1f, 1f));
            //         return;
            //     }
            //     else
            //     {
            //         if(rb.velocity.y >= 0){
            //             yVel = rb.velocity.y;
            //             if(yVel >= 0)
            //             {
            //                 yVel *= -1;
            //             }
            //             rb.velocity =new Vector2(rb.velocity.x,yVel);
            //         }
            //         if(rb.velocity.x <= 0){
            //             xVel = rb.velocity.x;
            //             if(xVel <= 0)
            //             {
            //                 xVel *= -1;
            //             }
            //             rb.velocity =new Vector2(xVel, rb.velocity.y);
            //         }
            //         // rb.velocity = new Vector2(-rb.velocity.y,-rb.velocity.x);
            //         // rb.velocity = new Vector2(0f, 0f);
            //         return;
            //     }           
            //  }
            //  else if(col.transform.position.x - 0.5f > transform.position.x){
            //     if(col.transform.position.y + 0.5f < transform.position.y)
            //     {
            //         if(rb.velocity.y <= 0){
            //             yVel = rb.velocity.y;
            //             if(yVel <= 0)
            //             {
            //                 yVel *= -1;
            //             }
            //             rb.velocity =new Vector2(rb.velocity.x,yVel);
            //         }
            //         if(rb.velocity.x >= 0){
            //             xVel = rb.velocity.x;
            //             if(xVel >= 0)
            //             {
            //                 xVel *= -1;
            //             }
            //             rb.velocity =new Vector2(xVel, rb.velocity.y);
            //         }
            //         // rb.velocity = new Vector2(-rb.velocity.y,-rb.velocity.x);
            //         // rb.velocity = new Vector2(0f, 0f);
            //         return;
            //     }
            //     else if(col.transform.position.y + 0.5f > transform.position.y && col.transform.position.y - 0.5f < transform.position.y)
            //     {
            //         rb.position = rb.position * new Vector2(0f, 1f);
            //         rb.position = rb.position + new Vector2(col.transform.position.x - 0.8f, 0f);
            //         xVel = rb.velocity.x;
            //         xVel *= -1;
            //         rb.velocity =new Vector2(xVel, rb.velocity.y);
            //         // rb.velocity = rb.velocity * (new Vector2(-1f, 1f));
            //         return;
            //     }
            //     else
            //     {
            //         if(rb.velocity.y >= 0){
            //             yVel = rb.velocity.y;
            //             if(yVel >= 0)
            //             {
            //                 yVel *= -1;
            //             }
            //             rb.velocity =new Vector2(rb.velocity.x,yVel);
            //         }
            //         if(rb.velocity.x >= 0){
            //             xVel = rb.velocity.x;
            //             if(xVel >= 0)
            //             {
            //                 xVel *= -1;
            //             }
            //             rb.velocity =new Vector2(xVel, rb.velocity.y);
            //         }
            //         // rb.velocity = new Vector2(-rb.velocity.y,-rb.velocity.x);
            //         // rb.velocity = new Vector2(0f, 0f);
            //         return;
            //     }           
            //  }
            //  else
            //  {
                
            //     yVel = rb.velocity.y;
            //         yVel *= -1;
            //         rb.velocity =new Vector2(rb.velocity.x, yVel);
            //         return;
            //  }
            // Debug.Log("uderzenie");
            // detectedCollision = true;
        return;
        }
    }

    
}
