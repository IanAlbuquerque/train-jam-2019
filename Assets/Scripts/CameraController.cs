using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform player1Target;

    [SerializeField]
    Transform player2Target;

    [SerializeField]
    public float smoothSpeed = 0.125f;

    [SerializeField]
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = (player1Target.position - player2Target.position) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player1Target);
    }

    //CameraShaker.Instance.ShakeOnce(4f, 3f, .1f, 1.5f);
}
