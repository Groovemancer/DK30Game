using System.Collections;
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

    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (IsGrounded() && Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, environmentLayerMask);
        if (raycastHit.collider != null) {
            return true;
        } else {
            return false;
        }
    }
}


