using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] items = new GameObject[10];

    [SerializeField] GameObject additional;
    public GameObject[] inventoryPos = new GameObject[10];
    // [SerializeField] Sprite[] inventoryPos = new Sprite[10];
    public Sprite defaultSpr;
    
    public Sprite spr;

    public int count;

    public Player playerScript;
    public GameObject toShow;
    
    public Transform parent;

    public ItemLayer itemLayerScript;

    private AudioSource pickUpSource;
    public Player mainPlayer;


    void Start()
    {
        itemLayerScript = GameObject.Find("/MainPlayground/ItemLayer").GetComponent<ItemLayer>();

        for(int i = count; i < 10; i++){
            inventoryPos[i].GetComponent<Image>().color = new Color32(0,0,0,0);
        }

        pickUpSource = GameObject.Find("PickUpSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("PlayerLayer").transform.GetChild(0))
        {
            playerScript = GameObject.Find("PlayerLayer").transform.GetChild(0).GetComponent<Player>();
            mainPlayer = GameObject.Find("PlayerLayer").transform.GetChild(0).GetComponent<Player>();
            nextItem();
            useItem();
            settingInventory();
        }
        
        
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
        pickUpSource.Play();

         
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
            int pickedItemPosX = (int) (mainPlayer.playerPosX - 0.5f);
            int pickedItemPosY = (int) (mainPlayer.playerPosY - 0.5f);

            if(itemLayerScript.columns[pickedItemPosX].rows[pickedItemPosY] == false){
                toShow = Instantiate(items[0], new Vector3(mainPlayer.playerPosX,mainPlayer.playerPosY), Quaternion.identity, parent);
                itemLayerScript.columns[pickedItemPosX].rows[pickedItemPosY] = true;
                toShow.GetComponent<Item>().UseItem();
                Destroy(items[0]);


                for(int i = 0; i < count - 1; i++){
                    items[i] = items[i+1];
                }
                inventoryPos[count - 1].GetComponent<Image>().sprite = defaultSpr;
                inventoryPos[count - 1].GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                count--;
                
                
                pickUpSource.Play();

            }      
            
        }
    }
    
}
