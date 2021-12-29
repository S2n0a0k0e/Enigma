using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LawnScript : MonoBehaviour
{
    [SerializeField] Sprite lawn1;
    [SerializeField] Sprite lawn2;
    [SerializeField] Sprite lawn3;
    [SerializeField] Sprite lawn4;
    Sprite actualTexture;
    Image m_Image;

    void Start()
    {
        m_Image = GetComponent<Image>();
       SetRandomTexture ();
       m_Image.sprite = actualTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetRandomTexture ()
    {
        int index = Random.Range(0,4);
        switch (index)
        {
            case 0:
                actualTexture = lawn1;
                break;
            case 1:
                actualTexture = lawn2;
                break;
            case 2:
                actualTexture = lawn3;
                break;
            case 3:
                actualTexture = lawn4;
                break;
        }
    }
    
}
