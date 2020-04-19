using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player, cameraPivot;
    [SerializeField] Vector3 offset;
    
    public Vector3 camOffset;
    public float rotSpeed = 1;

    Vector2 mouseDir = Vector2.zero;


    private void OnEnable()
    {
        
        GameTriggers.OnPlayerAssigned += AssignPlayer;
    }

    private void OnDisable()
    {
        GameTriggers.OnPlayerAssigned -= AssignPlayer;

    }

    void AssignPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cameraPivot = player.GetChild(2);
        cameraPivot.transform.rotation = Quaternion.identity;
        transform.rotation = Quaternion.identity;

        transform.position = player.position + offset;
        Camera.main.transform.parent = cameraPivot;

        

    }

    // Use this for initialization
    void Awake()
    {
        
        //AssignPlayer();
        //transform.position = player.position + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mouseDir.x += Input.GetAxis("Mouse X") * rotSpeed;
        mouseDir.y -= Input.GetAxis("Mouse Y") * rotSpeed;
        mouseDir.y = Mathf.Clamp(mouseDir.y, -35, 60);

        
        transform.LookAt(cameraPivot);

        cameraPivot.rotation = Quaternion.Euler(mouseDir.y, mouseDir.x, 0);
        player.rotation = Quaternion.Euler(0, mouseDir.x, 0);

        

    }
}
