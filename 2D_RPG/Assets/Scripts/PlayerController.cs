using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    GroundDetector groundDetector;

    public float speed;
    public float jumpForce;
    [SerializeField] bool showGroundTest;
    [SerializeField] Vector2 GroundRayPoint;
    [SerializeField] float GroundRaycastDistance;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") < 0;
        }

        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        animator.SetFloat("Velocity_X", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetFloat("Velocity_Y", rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && groundDetector.IsTouchingGround())
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }



}
