using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwampScript : MonoBehaviour
{
    [SerializeField] Sprite space1;
    [SerializeField] Sprite space2;
    [SerializeField] Sprite space3;
    [SerializeField] Sprite space4;
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
                actualTexture = space1;
                break;
            case 1:
                actualTexture = space2;
                break;
            case 2:
                actualTexture = space3;
                break;
            case 3:
                actualTexture = space4;
                break;
        }
    }
    
}
