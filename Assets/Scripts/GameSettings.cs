using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
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
    public GameObject activeOxydes;
    public int toWin;

    public bool zPressed;

    // Start is called before the first frame update
    void Start()
    {
        tableSize  = 2*oxydePairs;
        listOfAll = new int[tableSize];
        shuffledList= new int[tableSize];
        activeOxydes = null;
        toWin = oxydePairs;
        shuffleOxydes();
        colorDots();    
    }

    // Update is called once per frame
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
        WinLevel();
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
                colorDot = oxydes[i].transform.GetChild(2).GetComponent<Image>();
                colorDot.sprite = colors[shuffledList[i]];                    
        }
    }

    public void activationOfOxydes(GameObject oxyde, GameObject position){
        position = oxyde;
    }

    IEnumerator NextLevel()
    {
        yield return new  WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void WinLevel()
    {
        if(toWin == 0)
        {
            StartCoroutine(NextLevel());
        }
    }
    
}
