using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] int oxydePairs;
    int tableSize;
    [SerializeField] int[] listOfAll;
    [SerializeField] int[] shuffledList;
    // Start is called before the first frame update
    void Start()
    {
        tableSize  = 2*oxydePairs;
        listOfAll = new int[tableSize];
        shuffledList= new int[tableSize];
        shuffleOxydes();
        
        
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
}
