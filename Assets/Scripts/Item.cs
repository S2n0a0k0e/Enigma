using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public Inventory invScript;
    public ItemLayer itemLayerScript;
    public Rigidbody2D rb;

    

    public Player playerScript;
    public GameSettings gameSettingsScript;

    public Player mainPlayer;
    

    void Start()
    {
        invScript = GameObject.Find("/Inventory/Inventory").GetComponent<Inventory>();
        itemLayerScript = GameObject.Find("/MainPlayground/ItemLayer").GetComponent<ItemLayer>();
        gameSettingsScript = GameObject.Find("LevelSettings").GetComponent<GameSettings>();
        mainPlayer = GameObject.Find("PlayerLayer/Player").GetComponent<Player>();
        
    }

    void Update()
    {
        
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        
        if(!gameSettingsScript.zPressed){
            playerScript = col.gameObject.GetComponent<Player>();
            int pickedItemPosX = (int) (playerScript.playerPosX - 0.5f);
            int pickedItemPosY = (int) (playerScript.playerPosY - 0.5f);

            invScript.fillInventory(gameObject);
            // transform.position = new Vector2(0,0);
            itemLayerScript.columns[pickedItemPosX].rows[pickedItemPosY] = false;
        }
        
    } 

    public void UseItem()
    {
        if(gameObject.tag == "Document")
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<DocumentItem>().ActiveDocument();
            itemLayerScript.columns[(int)(mainPlayer.playerPosX - 0.5f)].rows[(int)(mainPlayer.playerPosY - 0.5f)] = false;
            Destroy(this.gameObject);
            Debug.Log("Destroyed");
        }
    }
}
