using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] items = new GameObject[10];
    [SerializeField] GameObject[] inventoryPos = new GameObject[10];
    // [SerializeField] Sprite[] inventoryPos = new Sprite[10];

    public Sprite spr;

    public int count = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        settingInventory();
    }

    public void settingInventory(){
        for(int i = 0; i < count; i++){
            spr = items[i].GetComponent<Image>().sprite;
            inventoryPos[i].GetComponent<Image>().sprite = spr;
            
        }
    }

    public void fillInventory(GameObject itemToInsert){
        count++;
        for(int i = count; i >0; i--){
            items[i] = items[i-1];  
        }
        items[0] = itemToInsert;
    }
}
