using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothing = 0.3f;
    [SerializeField] float maxSpeed = 10;

    Vector3 vel = Vector3.zero;

    // Use this for initialization
    void awake()
    {
        transform.position = player.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 targetPos = player.TransformPoint(offset);
        transform.LookAt(player);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoothing, maxSpeed);

    }
}
