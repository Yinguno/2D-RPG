using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] Vector2 size;
    public LayerMask layer;
    public float distance;
    [SerializeField] bool isTouchingGround;
    [SerializeField] bool showRay;



    public delegate void landEventHandler();
    public event landEventHandler onLand;


    void Start()
    {

    }


    void Update()
    {
        UpdateGroundTouchState();

    }

    void UpdateGroundTouchState()
    {
        if (!IsTouchingGround() && IsBoxCastHit())
        {
            TriggerOnLandEvent();
        }
        SetIsTouchingGround(IsBoxCastHit());

    }

    private void TriggerOnLandEvent()
    {
        if (IsTouchingGround())
        {
            onLand?.Invoke();
        }
    }

    bool IsBoxCastHit()
    {
        RaycastHit2D hit2D = Physics2D.BoxCast(transform.position, size, 0f, Vector2.down, distance, layer);
        if (hit2D.collider != null)
        {
            Debug.Log(hit2D.collider.name);
        }
        return hit2D.collider != null;
    }


    public bool IsTouchingGround()
    {
        return isTouchingGround;

    }
    void SetIsTouchingGround(bool value)
    {
        isTouchingGround = value;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + (Vector3)Vector2.down * distance, size);
    }





}
