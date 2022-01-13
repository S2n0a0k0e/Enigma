using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] int oxydePairs;
    int tableSize;
    [SerializeField] int[] listOfAll;
    [SerializeField] int[] shuffledList;

    [SerializeField] Sprite[] colors;

    [SerializeField] GameObject[] oxydes;

    public Image colorDot;
    // Start is called before the first frame update
    void Start()
    {
        tableSize  = 2*oxydePairs;
        listOfAll = new int[tableSize];
        shuffledList= new int[tableSize];
        shuffleOxydes();
        colorDots();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void shuffleOxydes(){
        for(int i = 0; i < tableSize; i++){
            listOfAll[i] = i/2;
        }

        for(int i = 0; i < 2*oxydePairs; i++){
            int j = Random.Range(0,tableSize - 1);
            shuffledList[i] = listOfAll[j];
            for(int k = j; k < tableSize - 1; k++){
                listOfAll[k] = listOfAll[k+1];
            }
            tableSize--;
        }
    }

    private void colorDots(){
        for(int i = 0; i < 2*oxydePairs; i++){  
                colorDot = oxydes[i].GetComponent<Image>();
                colorDot.sprite = colors[shuffledList[i]];                    
        }
    }
}
