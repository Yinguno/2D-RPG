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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponentInChildren<GroundDetector>();
    }


    void FixedUpdate()
    {

        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && groundDetector.IsTouchingGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }



}
