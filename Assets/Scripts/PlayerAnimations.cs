using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    [SerializeField] GameObject targetGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetGameObject.GetComponent<GameSettings>().toWin == 0 && targetGameObject.GetComponent<GameSettings>().holesToWin == 0)
        {
            animator.SetBool("allOxydes", true);
        }
    }

    void DestroyPlayer(){
        Destroy(player);
    }
}
