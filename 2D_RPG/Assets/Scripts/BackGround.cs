using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform player;
    public Transform Camera_BackGround;
    public Vector2 offset;
    public float distanceFromCamera;

    private void Update()
    {
        MoveBGCamera();
    }
    private void MoveBGCamera()
    {

        Camera_BackGround.position = ConvertMainCameraPosToBackGroundPos();
    }

    private Vector3 ConvertMainCameraPosToBackGroundPos()
    {
        Vector3 pos = (Vector3)offset + Camera.main.transform.position * distanceFromCamera;
        pos.z = Camera.main.transform.position.z;
        return pos;
    }
}
