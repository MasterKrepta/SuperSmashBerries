using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;

    private void OnEnable()
    {
        GameTriggers.OnPlayerAssigned += AssignPlayer;
    }

    private void OnDisable()
    {
        GameTriggers.OnPlayerAssigned -= AssignPlayer;

    }

    private void Start()
    {
        AssignPlayer(); 
    }
    
    void AssignPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public 
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed);
    }
}
