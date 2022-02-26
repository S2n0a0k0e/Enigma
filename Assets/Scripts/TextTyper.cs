 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using TMPro;
 
 public class TextTyper : MonoBehaviour {
 
     public float letterPause = 0.05f;
 
     string message;
     string[] lines;
     TextMeshProUGUI textComp;
 
     bool isVisible = false;

     Image parentImage;
     void Start () {
         textComp = GetComponent<TextMeshProUGUI>();
         textComp.text = "";    
         parentImage = this.transform.parent.gameObject.GetComponent<Image>();
     }

     void Update()
     {
         SetVisibility();
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
         isVisible = false;
     }

     public void TypeDocumentText (string textToWrite)
     {
         isVisible = true;
         lines = textToWrite.Split('\n');
         textComp.text = "";
         StartCoroutine(TypeText());
     }

     public void SetVisibility()
     {
         if(isVisible)
         {
             parentImage.color = new Color32(0,0,0,255); 
         }
         else 
         {
             parentImage.color = new Color32(255,255,255,0); 
         }
     }
 }
