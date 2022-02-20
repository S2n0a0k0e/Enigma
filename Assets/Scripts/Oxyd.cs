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
  

    void Start() 
    {
        oxydHitSource = GameObject.Find("OxydHitSound").GetComponent<AudioSource>();
        oxydPairSource = GameObject.Find("OxydPairSound").GetComponent<AudioSource>();
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
                Debug.Log("adlslanl");
            }     
            else{
                if(this.transform.parent.gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().sprite 
                    != activeOxyd.transform.GetChild(2).gameObject.GetComponent<Image>().sprite){
                    targetGameObject.GetComponent<GameSettings>().activeOxydes = this.transform.parent.gameObject;
                    activeOxyd.transform.GetChild(4).gameObject.GetComponent<Oxyd>().animator.SetBool("isHit", false);
                }
                else{
                    activeOxyd.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    this.transform.parent.gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
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
    }

    public void abl(){
        spr.color = new Color32(255,255,255,255);
    }
}
