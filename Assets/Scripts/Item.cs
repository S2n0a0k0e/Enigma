using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public Inventory invScript;
    public ItemLayer itemLayerScript;
    public Rigidbody2D rb;

    public bool zPressed;

    public Player playerScript;
    

    void Start()
    {
        invScript = GameObject.Find("/Inventory/Inventory").GetComponent<Inventory>();
        itemLayerScript = GameObject.Find("/MainPlayground/ItemLayer").GetComponent<ItemLayer>();
        
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
            int pickedItemPosX = (int) (playerScript.playerPosX - 0.5f);
            int pickedItemPosY = (int) (playerScript.playerPosY - 0.5f);
            Debug.Log(pickedItemPosX);
            Debug.Log(pickedItemPosY);


            invScript.fillInventory(gameObject);
            transform.position = new Vector2(0,0);
            itemLayerScript.columns[pickedItemPosX].rows[pickedItemPosY] = false;
        }
        
    } 
}
