using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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

    public float playerPosX;
    public float playerPosY;

    private AudioSource hitStoneSource;

    public GameObject particleEffect;
    // public GameObject effect;

    public Transform effectParent;

    

    void Start()
    {
        particleEffect = GameObject.Find("ParticleOnHit");
    }
    void Update ()
    {
        MoveMouse ();
        VelocityChanger ();
        getPlayerPos();
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

    void getPlayerPos()
    {
        int plPx = (int) (rb.position.x);
        int plPy = (int) (rb.position.y);
        playerPosX = (float) (plPx + 0.5);
        playerPosY = (float) (plPy + 0.5);
    }

    void VelocityChanger ()
    {
        float velX = 0.0f;
        float velY = 0.0f;
        float changeVelocity = 0.035f;
        
        
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
            if(rb.velocity.y > 0f) 
            {
                rb.velocity *= new Vector2(1f, ((velX - changeVelocity)/velX));
            }
            if(rb.velocity.y < 0f) 
            {
                rb.velocity *= new Vector2(1f, ((velX - changeVelocity)/velX));
            }
            if(rb.velocity.x > 0f) 
            {
                rb.velocity = rb.velocity + new Vector2(-changeVelocity, 0f);
            }
            if(rb.velocity.x < 0f) 
            {
                rb.velocity = rb.velocity + new Vector2(changeVelocity, 0f);
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
        
        
    }
    
    void OnGUI()
    {
        range = range + Time.deltaTime;
        if(range > 1f){
            Event e = Event.current;
            mouseX1 = Input.GetAxis("Mouse X");
            mouseY1 = Input.GetAxis("Mouse Y");

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
             
            mouseX1 /= 15;
            mouseY1 /= 15;

            if(mouseX1 < 0.1f && mouseX1 > 0f){
                mouseX1 = 0.08f;
            }
            if(mouseY1 < 0.1f && mouseY1 > 0f){
                mouseY1 = 0.08f;
            }

            range = 0.0f;
        }   
            
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "UnmovableBlock")
        {
            hitStoneSource = GameObject.Find("HitStoneSound").GetComponent<AudioSource>();
            hitStoneSource.Play();
            StartCoroutine(HitEffect(col));
        }
        else if(col.gameObject.tag == "Player")
        {
            StartCoroutine(HitEffect(col));
        }
    }

    IEnumerator HitEffect(Collision2D col)
    {
        GameObject effect;
        effect = Instantiate(particleEffect, new Vector3(col.contacts[0].point.x,
                col.contacts[0].point.y,-30), Quaternion.identity, particleEffect.transform.parent);
        yield return new WaitForSeconds(1);
        Destroy(effect);
    }

    void LockPlayer()
    {
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }
    
}
