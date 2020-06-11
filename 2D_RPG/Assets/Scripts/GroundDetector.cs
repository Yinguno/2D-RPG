using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] Vector2 size;
    public LayerMask layer;
    public float distance;
    public float radius;
    [SerializeField] bool isTouchingGround;
    [SerializeField] bool showRay;


    public delegate void landEventHandler();
    public event landEventHandler onLand;





    void Start()
    {

    }


    void FixedUpdate()
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
        RaycastHit2D[] hit2Ds = Physics2D.BoxCastAll(transform.position, size, 0f, Vector2.down, distance, layer);
        //RaycastHit2D[] hit2Ds = Physics2D.CircleCastAll(transform.position, radius, Vector2.down, distance, layer);
        foreach (RaycastHit2D hit2D in hit2Ds)
        {
            //Debug.Log(hit2D.transform.name);
        }


        return hit2Ds.Length > 0;
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
        Gizmos.DrawCube(transform.position + Vector3.down * distance, size);
        //Gizmos.DrawSphere(transform.position + Vector3.down * distance, radius);
    }




}
