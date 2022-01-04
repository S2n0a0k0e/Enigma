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
    private float range = 0.0f;
    

    // Start is called before the first frame update
    void Update ()
    {
        MoveMouse ();
        VelocityChanger ();
    }

    void MoveMouse () 
    {
        OnGUI ();
        if(Input.GetAxis("Mouse X")<0){
            rb.velocity = rb.velocity + new Vector2((-mouseX1), 0f);
            
        }
        if(Input.GetAxis("Mouse X")>0){
            rb.velocity = rb.velocity + new Vector2(mouseX1, 0f);
            
        }
        if(Input.GetAxis("Mouse Y")<0){
            rb.velocity = rb.velocity + new Vector2(0f, (-mouseY1));
            
        }
        if(Input.GetAxis("Mouse Y")>0){
            rb.velocity = rb.velocity + new Vector2(0f, (mouseY1));
            
        }
    }

    void VelocityChanger ()
    {
        // mouseX1 = Mathf.Log(mouseX1 + 1f);
        // mouseY1 = Mathf.Log(mouseY1 + 1f);
        float velX = 0.0f;
        float velY = 0.0f;
        float changeVelocity = 0.04f;
        
        
        if(rb.velocity.x >= 0f){
            velX = rb.velocity.x;
        }
        else{
            velX = -rb.velocity.x;
        }
        if(rb.velocity.y >= 0f){
            velY = rb.velocity.y;
        }
        else{
            velY = -rb.velocity.y;
        }
        
        if(velX > velY){
            if(rb.velocity.x > 0f) 
            {
                rb.velocity = rb.velocity + new Vector2(-changeVelocity, 0f);
            }
            if(rb.velocity.x < 0f) 
            {
                rb.velocity = rb.velocity + new Vector2(changeVelocity, 0f);
            }
            if(rb.velocity.y > 0f) 
            {
                rb.velocity *= new Vector2(1f, ((velX - changeVelocity)/velX));
            }
            if(rb.velocity.y < 0f) 
            {
                rb.velocity *= new Vector2(1f, ((velX - changeVelocity)/velX));
            }
        }
        else {
            if(rb.velocity.x > 0f) 
            {
                rb.velocity *= new Vector2(((velY - changeVelocity)/velY), 1f);
            }
            if(rb.velocity.x < 0f) 
            {
                rb.velocity *= new Vector2(((velY - changeVelocity)/velY), 1f);
            }
            if(rb.velocity.y > 0f) 
            {
                rb.velocity = rb.velocity + new Vector2(0f, -changeVelocity);
            }
            if(rb.velocity.y < 0f) 
            {
                rb.velocity = rb.velocity + new Vector2(0f, changeVelocity);
            }
        }
        
        // Debug.Log(rb.velocity.x);
        
    }
    
    void OnGUI()
    {
        range = range + Time.deltaTime;
        if(range > 1f){
            Event e = Event.current;
            mouseX1 = Input.GetAxis("Mouse X");
            mouseY1 = Input.GetAxis("Mouse Y");
            Debug.Log(mouseX1);
            // deltaY = mouseY1 - mouseY2;
            // deltaX = mouseX1 - mouseX2;
            // Debug.Log(deltaX);
            if(mouseX1 < 0){
                mouseX1 *= -1;
            }
            if(mouseY1 < 0){
                mouseY1 *= -1;
            }
            if(mouseX1 != 0){
                mouseX1 = Mathf.Log(mouseX1 * 300f);
            }
            if(mouseY1 != 0){
                mouseY1 = Mathf.Log(mouseY1 * 300f);
            }
             
            // Debug.Log(deltaY);
            mouseX1 /= 15;
            mouseY1 /= 15;
            // Debug.Log(mouseX1);

            if(mouseX1 < 0.1f && mouseX1 > 0f){
                mouseX1 = 0.08f;
            }
            if(mouseY1 < 0.1f && mouseY1 > 0f){
                mouseY1 = 0.08f;
            }

            
            // Debug.Log(deltaX);
            // Debug.Log(deltaY);
            range = 0.0f;
        }   
            
    }
    
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "UnmovableBlock")
        {
        
        return;
        }
    }

    
}
