using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    GroundDetector groundDetector;

    public float walkVelocity;
    public float jumpVelocity;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public int sticklayer = 10;
    public Vector2 size;
    public float distance;

    bool isMovingDown;

    public Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        RaycastBox();


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        rb.velocity = new Vector2(walkVelocity * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        animator.SetFloat("Velocity_X", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetFloat("Velocity_Y", rb.velocity.y);


        if (rb.velocity.y >= 0.1f || isMovingDown)
        {
            IgnoreStickCollision(true);
        }
        else
        {
            IgnoreStickCollision(false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !isMovingDown && Mathf.Abs(rb.velocity.y) <= 0.1f)
        {

            StartCoroutine(MoveDown());
        }


        if (Input.GetKey(KeyCode.Space) && groundDetector.IsTouchingGround() && !isMovingDown)
        {
            animator.SetTrigger("Jump");
            //Debug.Log("Jump " + groundDetector.IsTouchingGround());
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }



    }

    private void IgnoreStickCollision(bool value)
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, sticklayer, value);
    }

    IEnumerator MoveDown()
    {
        isMovingDown = true;
        yield return new WaitForSeconds(0.4f);

        isMovingDown = false;
    }

    private void RaycastBox()
    {
        RaycastHit2D[] hit2Ds = Physics2D.BoxCastAll(transform.position, size, 0f, direction, distance);

        foreach (RaycastHit2D hit2D in hit2Ds)
        {
            Debug.Log(hit2D.collider.gameObject.layer);
            if (hit2D.collider.gameObject.layer == sticklayer && !isMovingDown && Mathf.Abs(rb.velocity.y) < 0.1f)
            {
                StartCoroutine(MoveDown());
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + ((Vector3)direction * distance), size);
    }



}
