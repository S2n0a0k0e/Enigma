using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private bool timeTick = true;

    int milisecondsCounter = 0;

    public int minutes = 0;

    public int seconds1 = 0;
    public int seconds2 = 0;

    public string typeOfTime;

    void Update()
    {
        if(timeTick)
        {
            StartCoroutine(TimeIncreasing());
        }

        TimeConverter();
        TimeDisplay();
    }
    
    IEnumerator TimeIncreasing()
    {
        timeTick = false;
        yield return new WaitForSeconds(0.1f);
        milisecondsCounter++;
        timeTick = true;
    }

    private void TimeConverter()
    {
        minutes = milisecondsCounter/600;
        seconds1 = ((milisecondsCounter - minutes*600)/100);
        seconds2 = ((milisecondsCounter - minutes*600 - seconds1*100)/10);
    }

    private void TimeDisplay()
    {
        switch (typeOfTime)
        {
            case "Minutes":
                gameObject.GetComponent<TextMeshProUGUI>().text = minutes.ToString();
                break;
            case "Seconds1":
                gameObject.GetComponent<TextMeshProUGUI>().text = seconds1.ToString();
                break;
            case "Seconds2":
                gameObject.GetComponent<TextMeshProUGUI>().text = seconds2.ToString();
                break;
            default:
                break;
        }
    }

}
