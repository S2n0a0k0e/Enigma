using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxyd : MonoBehaviour
{
    [SerializeField] GameObject targetGameObject; 
    public Animator animator;
    Image spr;
    [SerializeField] Sprite sprit; 
    private AudioSource oxydHitSource;
    private AudioSource oxydPairSource;
    private GameObject questionMarkObject;

    public GameObject questionMark;

    public Image shadow;
    public Sprite shadowIm1;
    public Sprite shadowIm2;
  

    void Start() 
    {
        oxydHitSource = GameObject.Find("OxydHitSound").GetComponent<AudioSource>();
        oxydPairSource = GameObject.Find("OxydPairSound").GetComponent<AudioSource>();
        shadow = this.transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    void OnCollisionEnter2D(Collision2D col){
            var activeOxyd = targetGameObject.GetComponent<GameSettings>().activeOxydes;

            spr = GetComponent<Image>();
            spr.sprite = sprit;
        if(!animator.GetBool("isHit")){ 
            animator.SetBool("isHit", true);  
            oxydHitSource.Play();
            if(activeOxyd == null){
                targetGameObject.GetComponent<GameSettings>().activeOxydes = this.transform.parent.gameObject;
                questionMarkObject = Instantiate(questionMark,
                    new Vector3(this.transform.parent.gameObject.transform.position.x,this.transform.parent.gameObject.transform.position.y), 
                    Quaternion.identity, this.transform.parent);
                Debug.Log("adlslanl");
            }     
            else{
                if(this.transform.parent.gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().sprite 
                    != activeOxyd.transform.GetChild(2).gameObject.GetComponent<Image>().sprite){
                    targetGameObject.GetComponent<GameSettings>().activeOxydes = this.transform.parent.gameObject;
                    activeOxyd.transform.GetChild(4).gameObject.GetComponent<Oxyd>().animator.SetBool("isHit", false);
                    Destroy(activeOxyd.transform.GetChild(5).gameObject);
                    questionMarkObject = Instantiate(questionMark,
                     new Vector3(this.transform.parent.gameObject.transform.position.x,this.transform.parent.gameObject.transform.position.y), 
                     Quaternion.identity, this.transform.parent);
                }
                else{
                    activeOxyd.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    this.transform.parent.gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    Destroy(activeOxyd.transform.GetChild(5).gameObject);
                    targetGameObject.GetComponent<GameSettings>().activeOxydes = null;
                    targetGameObject.GetComponent<GameSettings>().toWin --;
                    oxydPairSource.Play();
                }
            }          
        }
        else{     
            
        }

        
    }

    public void ena(){
        spr.color = new Color32(255,255,255,0);
        shadow.sprite = shadowIm2;
    }

    public void abl(){
        spr.color = new Color32(255,255,255,255);
        shadow.sprite = shadowIm1;
    }
}
