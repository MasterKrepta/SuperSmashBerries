using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform player;
    public Transform BaseTarget;
    public Transform currentTarget;
    public float moveSpeed = 0.15f;
    NavMeshAgent agent;

 

    public float DistanceToPlayer;
    public float DistanceToBase;

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
        //agent = GetComponent<NavMeshAgent>();
        BaseTarget = GameObject.FindGameObjectWithTag("Base").transform;
        AssignPlayer(); 
    }
    
    void AssignPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentTarget = player;
        
    }


    public 
    // Update is called once per frame
    void Update()
    {
        DistanceToBase = Vector3.Distance(BaseTarget.position, transform.position);
        DistanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (DistanceToPlayer < DistanceToBase)
        {
            TargetPlayer();
        }
        else
        {
            TargetBase();
        }

        if (DistanceToPlayer > 2000  || DistanceToBase > 2000)
        {
            this.GetComponent<IDamagable>().TakeDamage(5000); // Make sure they die
        }
        //agent.SetDestination(currentTarget.position);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        transform.LookAt(currentTarget.position);
        //print("Moving to " + currentTarget.name);
    }


    void TargetPlayer()
    {
        
        AssignPlayer();
    }

    void TargetBase()
    {
        currentTarget = BaseTarget;
    }
}
