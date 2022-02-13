using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] items = new GameObject[10];

    [SerializeField] GameObject additional;
    [SerializeField] GameObject[] inventoryPos = new GameObject[10];
    // [SerializeField] Sprite[] inventoryPos = new Sprite[10];
    public Sprite defaultSpr;

    public Sprite spr;

    public int count;

    public Player playerScript;
    public GameObject toShow;
    
    public Transform parent;

    public ItemLayer itemLayerScript;


    void Start()
    {
        itemLayerScript = GameObject.Find("/MainPlayground/ItemLayer").GetComponent<ItemLayer>();
        // playerScript = GameObject.Find("/PlayerLayer/Player").GetComponent<Player>();

        for(int i = count; i < 10; i++){
            inventoryPos[i].GetComponent<Image>().color = new Color32(0,0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nextItem();
        useItem();
        settingInventory();
        
    }

    public void settingInventory(){
        for(int i = 0; i < count; i++){
            spr = items[i].GetComponent<Image>().sprite;
            if(spr != defaultSpr){
                inventoryPos[i].GetComponent<Image>().sprite = spr;
                inventoryPos[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else{
                inventoryPos[i].GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            }
            
        }
    }

    public void fillInventory(GameObject itemToInsert){
        if(count <= 9){
            count++;
        }
        
        for(int i = count - 1; i > 0; i--){
            items[i] = items[i-1];  
        }
        // items[0] = itemToInsert;
        items[0] = Instantiate(itemToInsert, new Vector3(0,0), Quaternion.identity, parent);
        Destroy(itemToInsert);

         
    }

    public void nextItem(){
        if (Input.GetKeyDown("space"))
        {
            additional = items[0];
            for(int i = 0; i < count - 1; i++){
                items[i] = items[i+1];
            }
            items[count - 1] = additional;
        }
    }
    
    public void useItem(){
        
        if(Input.GetKeyDown("z") && count >= 1)
        {
            int pickedItemPosX = (int) (playerScript.playerPosX - 0.5f);
            int pickedItemPosY = (int) (playerScript.playerPosY - 0.5f);

            if(itemLayerScript.columns[pickedItemPosX].rows[pickedItemPosY] == false){
                toShow = Instantiate(items[0], new Vector3(playerScript.playerPosX,playerScript.playerPosY), Quaternion.identity, parent);
                Destroy(items[0]);


                for(int i = 0; i < count - 1; i++){
                    items[i] = items[i+1];
                }
                inventoryPos[count - 1].GetComponent<Image>().sprite = defaultSpr;
                inventoryPos[count - 1].GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                count--;
                itemLayerScript.columns[pickedItemPosX].rows[pickedItemPosY] = true;
            }      
            
        }
    }
    
}
