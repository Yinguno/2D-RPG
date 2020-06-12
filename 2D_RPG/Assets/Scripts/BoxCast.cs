using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoxCast
{
    private BoxCast() { }
    public GameObject gameObject;
    [SerializeField] Vector2 size;
    [SerializeField] Vector2 direction;
    [SerializeField] float distance;
    [SerializeField] float distance_jump;
    [SerializeField] int layerToIgnore = 10;
    [SerializeField] LayerMask layerToCast;
    [SerializeField] bool isboxDrawn = false;
    public bool isJumping = false;
    Collider2D collider;
    Collider2D GetCollider()
    {
        if (collider == null)
        {
            collider = gameObject.GetComponent<Collider2D>();
        }
        return collider;
    }
    RaycastHit2D[] hit2Ds;
    public void IgnoreLayerCollision(bool value)
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, layerToIgnore, value);
    }
    public void IgnoreCollision()
    {

        hit2Ds = CastAllWalkable();
        foreach (RaycastHit2D hit2D in hit2Ds)
        {
            if (hit2D.collider.gameObject.layer == layerToIgnore)
                Physics2D.IgnoreCollision(GetCollider(), hit2D.collider, true);
        }
    }
    public void CancelIgnoreCollision()
    {

        foreach (RaycastHit2D hit2D in hit2Ds)
        {
            if (hit2D.collider.gameObject.layer == layerToIgnore)
                Physics2D.IgnoreCollision(GetCollider(), hit2D.collider, false);
        }
    }

    public bool IsCastHit()
    {
        return CastAllWalkable().Length != 0;
    }
    public RaycastHit2D[] CastAllWalkable()
    {
        float distance;
        if (isJumping)
        {
            distance = distance_jump;
        }
        else
        {
            distance = this.distance;
        }
        RaycastHit2D[] hit2Ds = Physics2D.BoxCastAll(gameObject.transform.position, size, 0f, direction, distance, layerToCast);
        return hit2Ds;
    }
    public void Draw()
    {
        float distance;
        if (isJumping)
        {
            distance = distance_jump;
        }
        else
        {
            distance = this.distance;
        }
        if (isboxDrawn)
        {
            Gizmos.DrawCube(gameObject.transform.position + ((Vector3)direction * distance), size);
        }
    }

}
