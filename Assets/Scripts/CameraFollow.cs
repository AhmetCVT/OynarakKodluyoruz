using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;
    public Vector3 cameraOffset;
    public float smoothTime;

    private void LateUpdate()
    {
        Vector3 desiredPosition = targetPlayer.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothTime);

        transform.position = smoothedPosition;

        transform.LookAt(targetPlayer);
    }
}
