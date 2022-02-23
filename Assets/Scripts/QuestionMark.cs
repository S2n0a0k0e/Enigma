using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMark : MonoBehaviour
{
    private bool isBlinking = true;

    // Update is called once per frame
    void Update()
    {
        if(isBlinking)
        {
            StartCoroutine(QuestionMarkBlinking());
        }
        
    }
    IEnumerator QuestionMarkBlinking()
    {
        isBlinking = false;
        yield return new  WaitForSeconds(1);
        this.gameObject.GetComponent<Image>().color = new Color32(255,255,255,0);
        yield return new  WaitForSeconds(1);
        gameObject.GetComponent<Image>().color = new Color32(255,255,255,255);
        isBlinking = true;
    }
}
