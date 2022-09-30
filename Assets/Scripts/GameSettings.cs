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
    [SerializeField] GameObject[] ballList;
    [SerializeField] int[] listOfAll;
    [SerializeField] int[] shuffledList;
    [SerializeField] GameObject myCamera;
    [SerializeField] GameObject mainPlayer;
    [SerializeField] Sprite[] colors;

    [SerializeField] GameObject[] oxydes;
 
    public bool end = false;

    public Image colorDot;
    public GameObject activeOxydes;
    public int toWin;
    public int holesToWin;
    public int holesWin = 0;

    public bool zPressed;

    public int filledHolles;
    // Start is called before the first frame update
    void Start()
    {
        // ballList = new GameObject[holesToWin];
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
        filledHolles = 0;
        if(holesToWin > 0){
                for(int i = 0; i < ballList.Length; i++)
            {
                if(ballList[i].GetComponent<BallInHollow>().inHole)
                {
                    filledHolles++;
                }
            }
        }
        

        if(filledHolles == holesToWin)
        {
            holesWin = 0;
        }
        else
        {
            holesWin = 1;
        }
        EndLevel();
        WinLevel();
        MoveCamera();

    }


    private void MoveCamera(){
        if(mainPlayer)
        {
            if(myCamera.transform.position.x - mainPlayer.transform.position.x < -9.25f)
            {
                myCamera.transform.position = myCamera.transform.position + new Vector3(19f, 0f, 0f);
            }
            if(myCamera.transform.position.x - mainPlayer.transform.position.x > 9.25f)
            {
                myCamera.transform.position = myCamera.transform.position + new Vector3(-19f, 0f, 0f);
            }
        }
        
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
        if(toWin == 0 && holesWin == 0)
        {
            if(holesToWin > 0)
            {
                StartCoroutine(InHollow());
            }
            else
            {
                StartCoroutine(NextLevel());
            }
            
        }
    }

    public void EndLevel()
    {
        if(holesWin == 0 && end == true)
            {
                StartCoroutine(NextLevel());
            } 
        else
        {
            end = false;
        }
        
    }

    IEnumerator InHollow()
    {

        yield return new WaitForSeconds(2f);
        end = true;
        
    }
    
}
