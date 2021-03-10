using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

/// <summary>
/// Represents a target controller.
/// </summary>
public class TargetController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    float walkRadius = 0.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        RandomSpawn();
        Invoke("NavMeshMove", Random.Range(2.5f, 3.5f));
    }

    void RandomSpawn()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1))
        { 
            transform.position = hit.position;  
        }
    }

    void NavMeshMove()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition;
        if (NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1))
        {
            finalPosition = hit.position;            
            agent.SetDestination(finalPosition);
        }
        Invoke("NavMeshMove", Random.Range(2.5f, 3.5f));
    }

    void Update()
    {
        animator.SetFloat("speed", agent.velocity.magnitude);
    }
}