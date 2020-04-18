using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;

    [Range(0.01f, 1.0f)]
    public float smoothing = 0.5f;

    public bool LookAtPlayer = false;

    public bool orbitPlayer = true;

    public float rotSpeed = 5.0f;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.position;
    }

    // LateUpdate is called after Update methods
    void LateUpdate()
    {

        if (orbitPlayer)
        {
            Quaternion camAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotSpeed, Vector3.up);

            offset = camAngle * offset;
        }

        Vector3 newPos = player.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothing);

        if (LookAtPlayer || orbitPlayer)
            transform.LookAt(player);
    }
}
