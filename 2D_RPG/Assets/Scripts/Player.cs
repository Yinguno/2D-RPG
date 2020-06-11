using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    GroundDetector groundDetector;
    SpriteRenderer spriteRenderer;
    Animator animator;
    bool isFalling;
    bool isJumping;

    public float horizontalVelocity;
    public float jumpVelocity;


    [SerializeField] BoxCast stickBoxCast;
    [SerializeField] BoxCast groundBoxCast;

    /*    
    玩家功能：
    接收鍵盤操控：
    左右移動
    跳躍
    下降
    放櫻桃炸彈
    角色互動按鍵
    玩家屬性：
    移動速度
    血量
    玩家增益/異常狀態


    */

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


    }

    private void Update()
    {
        animator.SetFloat("Velocity_Y", rb.velocity.y);
    }
    private void OnDrawGizmos()
    {
        stickBoxCast.Draw();
        groundBoxCast.Draw();
    }

    public void HorizontalMove(float axis)
    {
        ApplyHorizontalMove(axis);
        FaceToAxis_Horizotal(axis);
        animator.SetFloat("Velocity_X", Mathf.Abs(axis));
    }

    public void Jump()
    {
        if (!isJumping && groundBoxCast.IsCastHit())
        {
            ApplyJump();
        }
    }
    public void Fall()
    {
        if (!isFalling)
        {

            StartCoroutine(FallIgnoreCollision());
        }
    }

    private void ApplyJump()
    {
        animator.SetTrigger("Jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        StartCoroutine(JumpIgnoreCollision());
    }

    IEnumerator FallIgnoreCollision()
    {
        isFalling = true;
        groundBoxCast.IgnoreCollision();
        //yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() =>
            {
                //Debug.Log(stickBoxCast.IsCastHit());
                return stickBoxCast.IsCastHit();
            }
        );
        yield return new WaitUntil(() =>
            {
                //Debug.Log(!stickBoxCast.IsCastHit());
                return !stickBoxCast.IsCastHit();
            }
        );

        groundBoxCast.CancelIgnoreCollision();
        isFalling = false;
    }
    IEnumerator JumpIgnoreCollision()
    {
        isJumping = true;
        stickBoxCast.IgnoreLayerCollision(true);
        yield return new WaitUntil(() =>
        {
            if (rb.velocity.y <= 0)
            {
                return !stickBoxCast.IsCastHit();
            }

            return rb.velocity.y <= 0;
        });
        stickBoxCast.IgnoreLayerCollision(false);
        isJumping = false;
    }

    private void ApplyHorizontalMove(float axis)
    {
        rb.velocity = new Vector2(horizontalVelocity * axis, rb.velocity.y);
    }

    private void FaceToAxis_Horizotal(float axis)
    {
        if (axis > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (axis < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

    }


}
