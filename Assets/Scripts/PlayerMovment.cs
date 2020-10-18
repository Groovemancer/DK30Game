using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public CharController2D controller;
    public float runSpeed = 25f;

    private bool jumpFlag = false;
    private bool jump = false;

    private float horizontalMove = 0f;

    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (jumpFlag) {
            jumpFlag = false;
        }

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    public void OnLanding() {
        jump = false;
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);

        if (jump) {
            jumpFlag = true;
        }
    }
}
 