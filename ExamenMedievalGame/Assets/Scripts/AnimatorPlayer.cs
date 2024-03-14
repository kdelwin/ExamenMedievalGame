using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) 
        {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }

    }
}
