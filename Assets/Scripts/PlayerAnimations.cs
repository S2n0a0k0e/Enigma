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
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((targetGameObject.GetComponent<GameSettings>().holesWin == 0 && targetGameObject.GetComponent<GameSettings>().end)
            ||  (targetGameObject.GetComponent<GameSettings>().holesToWin == 0 && targetGameObject.GetComponent<GameSettings>().toWin == 0))
        {
            animator.SetBool("allOxydes", true);
            Debug.Log(this.name);
        }

    }


    void DestroyPlayer(){
        Destroy(player);
    }
}
