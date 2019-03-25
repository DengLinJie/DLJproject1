using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
     
    public float runspeed = 40f;

    float HorizontalMove = 0f;
    bool jump = false;
    bool attack = false;
    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        animator.SetFloat("Speed",Mathf.Abs( HorizontalMove));
        

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJump", true);
        }
       
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJump", false);

    }
    void FixedUpdate()
    {
        //move character
        controller.Move(HorizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
    }
}
