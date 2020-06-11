using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform player;
    public Transform Camera_BackGround;
    public Vector2 offset;
    public float distanceFromCamera;

    private void FixedUpdate()
    {
        MoveBGCamera();
    }
    private void OnValidate()
    {
        MoveBGCamera();
    }
    private void MoveBGCamera()
    {

        Camera_BackGround.localPosition = ConvertMainCameraPosToBackGroundPos();
    }

    private Vector3 ConvertMainCameraPosToBackGroundPos()
    {
        Vector3 pos = (Camera.main.transform.position - (Vector3)offset) / distanceFromCamera;
        pos.z = Camera.main.transform.position.z;
        return pos;
    }
}
