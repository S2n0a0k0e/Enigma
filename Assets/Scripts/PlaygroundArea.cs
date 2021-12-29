using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundArea : MonoBehaviour
{
    [SerializeField] GameObject[] ann = new GameObject[260];
    GameObject[] ann1 = new GameObject[260];
    // Transform newParent = GetComponent<Transform> ();
    public Transform parent;
    int x = 0;
    int y = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 260; i++){
            y = i/20;
            x = i - (y*20);
             ann1[i] = Instantiate(ann[i], new Vector3(x + 0.5f,y + 0.5f), Quaternion.identity, parent);
            // ann1.transform.SetParent (newParent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
