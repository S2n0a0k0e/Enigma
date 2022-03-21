using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInHollow : MonoBehaviour
{
    public bool inHole = false;
    public bool stillInHole = false;
    public GameSettings gameScript;

    void Start()
    {

    }
    void Update()
    {
            if(inHole && !stillInHole)
        {
            gameScript.holesToWin--;    
            stillInHole = true;
            Debug.Log("ok");
        }
        // else if(inHole && stillInHole)
        // {
        //     gameScript.holesToWin++; 
        // }
    }
    
}
