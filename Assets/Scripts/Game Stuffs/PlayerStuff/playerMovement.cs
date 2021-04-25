using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontal = 0;
    public float speed = 40f;
    bool jump = false;
    bool crouch = false;
    float jumpSpeed = 0;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJump", true);
        }      
        
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }

    public void OnCrouch(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        //schmoovin
        controller.Move(horizontal * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
