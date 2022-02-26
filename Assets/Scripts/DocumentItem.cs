using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentItem : MonoBehaviour
{
    public string documentMessage;
    
    [SerializeField] TextTyper textTyperObject;
    void Start()
    {
        textTyperObject = GameObject.Find("MessageText").GetComponent<TextTyper>();
        documentMessage = GetComponent<Text>().text;
    }

    public void ActiveDocument()
    {
        textTyperObject.TypeDocumentText(documentMessage);
    }

}
