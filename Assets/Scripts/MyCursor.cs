using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour
{
    float MouseX;
    float MouseY;
    void Start()
    {
        
    }

    void Update () 
    {
        MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");
        transform.position += new Vector3(MouseX*4.8f,MouseY*3.2f,0);
    }
}
