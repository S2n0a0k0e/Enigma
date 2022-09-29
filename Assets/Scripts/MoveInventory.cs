using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInventory : MonoBehaviour
{
    public GameObject myCamera;

    private void moveInventory()
    {
        transform.position = myCamera.transform.position + new Vector3(0f, -6.5f, 4.98f);
    }

    void Update()
    {
        moveInventory();
    }

}
