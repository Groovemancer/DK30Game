﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public CharController2D controller;
    public float runSpeed = 25f;
    
    private bool jump = false;
    private float horizontalMove = 0f;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask environmentLayerMask;

    public Animator animator;
    private bool m_FacingRight = true;
    
    //shooting variables
    public Transform firePoint;
    public GameObject bulletPrefab;

    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (IsGrounded())
        {
            if (animator.GetBool("Jumping") == true)
            {
                //animator.SetBool("Jumping", false);
            }
        }

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jumping", true);
            //Debug.Log(animator.GetBool("Jumping"));
            //FindObjectOfType<AudioManager>().Play("Jump");
            jump = true;
        }

        //shooting logic
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        
        //check to see which way the character is moving
        if (horizontalMove > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (horizontalMove < 0 && m_FacingRight)
        {
            Flip();
        }

        animator.SetBool("Running", Mathf.Abs(horizontalMove) > 0);
        //animator.SetFloat("Horizontal", Mathf.Abs(horizontalMove));
        //Debug.Log(animator.GetBool("Running"));
        jump = false;
        
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, environmentLayerMask);
        if (raycastHit.collider != null)
        {
            animator.SetBool("Jumping", false);
            return true;
        }
        else
        {
            return false;
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Shoot()
    {
        //Start Shooting Animation
        animator.SetTrigger("Shooting");
        //Debug.Log("the player is shooting " + animator.GetBool("Shooting"));

        //create a bullet at a fire point
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


    }
}


