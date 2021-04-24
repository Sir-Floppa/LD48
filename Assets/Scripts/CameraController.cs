using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    float speed = 0.025f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        smoothPosition.z = -10;
        transform.position = smoothPosition;
    }
}
