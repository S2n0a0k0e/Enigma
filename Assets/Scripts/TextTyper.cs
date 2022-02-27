 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using TMPro;
 
 public class TextTyper : MonoBehaviour {
 
 private IEnumerator coroutine;
 private IEnumerator cor2;
 private IEnumerator cor3;
     public float letterPause = 0.05f;
 
     string message;
     string[] lines;
     TextMeshProUGUI textComp;
 
     bool isVisible = false;

     bool writing = false;

     Image parentImage;
     void Start () {
         textComp = GetComponent<TextMeshProUGUI>();
         textComp.text = "";    
         parentImage = this.transform.parent.gameObject.GetComponent<Image>();
         
     }

     void Update()
     {
         coroutine = TypeText();
         SetVisibility();
         StopWriting();
     }
 
     IEnumerator TypeText () {
         yield return new WaitForSeconds(0.1f);
         isVisible = true;
         writing = true; 
         cor3 = cor2;
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
         
         textComp.text = "";
         lines = textToWrite.Split('\n');
         StartCoroutine(coroutine);
         cor2 = coroutine;
         
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
     

    public void StopWriting()
    {
        if(writing)
        {
            if(Input.GetKeyDown("space")||Input.GetKeyDown("z"))
            {                
                StopCoroutine(cor3);
                isVisible = false;
                writing = false;
                textComp.text = "";
            }
             
        }
    }
 }
