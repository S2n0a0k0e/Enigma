using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public Inventory invScript;
    public Rigidbody2D rb;
    

    void Start()
    {
        invScript = GameObject.Find("/Inventory/Inventory").GetComponent<Inventory>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        invScript.fillInventory(gameObject);
        transform.position = new Vector2(0,0);
        // Destroy(gameObject);
        // gameObject.transform.position.x = -1000;
    } 
}
