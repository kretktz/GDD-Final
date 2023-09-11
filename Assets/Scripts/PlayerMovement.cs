﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public CapsuleCollider2D col;

    public float horizontal;
    private float speed = 4f;
    private float jumpingPower = 11f;

    private bool isFacingRight = true;
    private bool crouchHeld = false, isCrouching = false, 
                 isUnderPlatform = false, jump = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        // fetch components
        col = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        horizontal = Input.GetAxisRaw("Horizontal");

        // variable sent to the animator to trigger the walking animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //Stop movement when dialog is displayed
        if (DialogueManager.isActive == true)
        {
            horizontal = 0f;
            return;
        }

        // Crouching animation logic
        if (IsGrounded() && (crouchHeld || isUnderPlatform))
        {
            isCrouching = true;
        }
        else
        { 
            isCrouching = false;
        }

        animator.SetBool("isCrouching", isCrouching);

        crouchHeld = (IsGrounded() && Input.GetButton("Crouch")) ? true : false;

        

        // Jumping logic
        if (Input.GetButtonDown("Jump") && IsGrounded() && !crouchHeld)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (!IsGrounded())
        {
            jump = true;
        } else { jump = false; }

        animator.SetBool("Jump", jump);

      

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Detect box collision when crouching
        GetComponent<BoxCollider2D>().isTrigger = (crouchHeld || isUnderPlatform) ? true : false;
    }

    // Return whether the character is on the ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // Flip the character sprite from left to right depending on the direction faced
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        
    }

    // Collision detection funcs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
            isUnderPlatform = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
            isUnderPlatform = false;
    }

}

