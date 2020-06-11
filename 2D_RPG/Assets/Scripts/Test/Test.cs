using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector2 size;
    public Vector2 direction;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hit2Ds = Physics2D.BoxCastAll(transform.position, size, 0f, direction, distance);
        if (hit2Ds.Length != 0)
        {
            Debug.Log("hit");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + ((Vector3)direction * distance), size);
    }
}
