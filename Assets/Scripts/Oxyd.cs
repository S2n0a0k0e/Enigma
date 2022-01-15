using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxyd : MonoBehaviour
{
    Image spr;
    [SerializeField] Sprite sprit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col){
        spr = GetComponent<Image>();
        spr.sprite = sprit;
        Debug.Log("Hi");
    }
}
