using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharController2D : MonoBehaviour {
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private Transform groundCollider;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = 0.05f;

    private Rigidbody2D body;
    private Vector3 velocity = Vector3.zero;
    private bool grounded = true;
    private const float groundedRadius = 0.2f;

    public UnityEvent OnLandEvent;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        if (OnLandEvent == null) {
            OnLandEvent = new UnityEvent();
        }
    }

    private void FixedUpdate() {
        bool wasGrounded = grounded;
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCollider.position, groundedRadius, groundLayer);
        foreach(Collider2D collider in colliders) {
            if (collider.gameObject != gameObject) {
                grounded = true;
                if (!wasGrounded) {
                    OnLandEvent.Invoke();
                }
            }
        }
    }

    public void Move(float move, bool jump) {
        Vector3 targetVelocity = new Vector2(move * 10f, body.velocity.y);
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, MovementSmoothing);

        if (grounded && jump) {
            grounded = false;
            body.AddForce(new Vector2(0f, jumpForce));
        }
    }
}

