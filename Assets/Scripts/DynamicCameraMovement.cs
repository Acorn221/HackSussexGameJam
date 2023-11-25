using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCameraMovement : MonoBehaviour
{
    public Transform target; // The player's transform
    public float smoothTime = 0.3f; // Smoothing time for camera movement
    private Vector3 velocity = Vector3.zero; // Velocity for SmoothDamp

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0, 0, -10); // Offset the camera in the Z-axis
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
            transform.position = smoothedPosition;
        }
    }
}
