using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController2D : MonoBehaviour {
    [SerializeField] private LayerMask groundLayer;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = 0.05f;
    [Range(1, 50)] public float jumpVelocity;
    [Range(1, 10)] public float fallMultiplier;
    [Range(1, 10)] public float lowJumpMultiplier;


    private Rigidbody2D body;
    private Vector3 velocity = Vector3.zero;

    public void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    public void Update() {
        if (body.velocity.y < 0) {
            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (body.velocity.y > 0 && !Input.GetButton("Jump")) {
            body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void Move(float move, bool jump) {
        Vector3 targetVelocity = new Vector2(move * 10f, body.velocity.y);
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, MovementSmoothing);
        if (jump) {            
            body.velocity = body.velocity + Vector2.up * jumpVelocity;
        }
    }
}

