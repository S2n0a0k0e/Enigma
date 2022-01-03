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
    float range;
    public Rigidbody2D rb;
    bool detectedCollision = false;
    

    // Start is called before the first frame update
    void Update ()
    {
        MoveMouse ();
        VelocityChanger ();
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
        float changeVelocity = 0.04f;
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
                deltaX = Mathf.Log(deltaX) + 1f;
            }
            if(deltaY != 0){
                deltaY = Mathf.Log(deltaY) + 1f;
            }
            Debug.Log(deltaX);
            Debug.Log(deltaY);
            deltaX /= 15;
            deltaY /= 15;
            
            // Debug.Log(deltaX);
            // Debug.Log(deltaY);
            mouseX2 = mouseX1;
            mouseY2 = mouseY1;
            
    }
    
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "UnmovableBlock" && detectedCollision == false)
        {
        
        return;
        }
    }

    
}
