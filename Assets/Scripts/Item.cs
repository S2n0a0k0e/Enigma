using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public Inventory invScript;
    public Rigidbody2D rb;

    public bool zPressed;
    

    void Start()
    {
        invScript = GameObject.Find("/Inventory/Inventory").GetComponent<Inventory>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown("z"))
        {
            zPressed = true;
        }
        if(Input.GetKeyUp("z"))
        {
            zPressed = false;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        if(!zPressed){
            invScript.fillInventory(gameObject);
            transform.position = new Vector2(0,0);
        // Destroy(gameObject);
        // gameObject.transform.position.x = -1000;
        }
        
    } 
}
