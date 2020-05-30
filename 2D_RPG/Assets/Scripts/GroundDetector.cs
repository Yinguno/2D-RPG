using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] float distance;
    public LayerMask layer;
    [SerializeField] bool isTouchingGround;
    [SerializeField] bool showRay;



    public delegate void landEventHandler();
    public event landEventHandler onLand;


    void Start()
    {

    }


    void Update()
    {
        DetectGround();
        if (showRay)
        {
            Debug.DrawLine(transform.position, transform.position + (Vector3.down * distance));
        }
        isTouchingGround = IsTouchingGround();
    }

    void DetectGround()
    {

        if (IsTouchingGround())
        {
            onLand?.Invoke();
        }


    }

    public bool IsTouchingGround()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distance, layer.value);
        if (hit2D.collider != null)
            Debug.Log(hit2D.collider.name);
        return hit2D.collider != null;
    }


}
