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

    public int count = 2;

    void Start()
    {
        for(int i = count; i < 10; i++){
            inventoryPos[i].GetComponent<Image>().color = new Color32(0,0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        settingInventory();
        nextItem();
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
        
        for(int i = count - 1; i >0; i--){
            items[i] = items[i-1];  
        }
        items[0] = itemToInsert;
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
    
}
