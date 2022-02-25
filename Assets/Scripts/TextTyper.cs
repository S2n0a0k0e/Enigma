 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using TMPro;
 
 public class TextTyper : MonoBehaviour {
 
     public float letterPause = 0.05f;
 
     string message;
     string[] lines;
     TextMeshProUGUI textComp;
 
     // Use this for initialization
     void Start () {
         textComp = GetComponent<TextMeshProUGUI>();
         message = textComp.text;
         lines = message.Split('\n');
         textComp.text = "";
         StartCoroutine(TypeText ());
     }
 
     IEnumerator TypeText () {
         for(int i = 0; i < lines.Length; i++)
         {
         foreach (char letter in lines[i].ToCharArray()) {
             textComp.text += letter;
             yield return new WaitForSeconds (letterPause);
         }
         yield return new WaitForSeconds(1);
         textComp.text = "";
         }
     }
 }
