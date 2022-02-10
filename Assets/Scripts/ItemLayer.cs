using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemLayer : MonoBehaviour
{
    public static int X, Y;
    [System.Serializable]
    public class Column
    {
        public bool[] rows = new bool[13];
    }

    public Column[] columns = new Column[20];

    
}
