using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundArea : MonoBehaviour
{
    [SerializeField] GameObject[] ann = new GameObject[1];
    int x = 0;
    int y = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 1; i++){
            x = i/13;
            y = (259 - 13*y);
            ann[i].transform.position = new Vector3(x + 0.5f, y + 0.5f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
