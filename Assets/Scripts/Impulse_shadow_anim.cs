using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse_shadow_anim : MonoBehaviour
{
    public Animator animator;
    
    public void stopAnim(){
        animator.SetBool("isHit", false);
    }
}
