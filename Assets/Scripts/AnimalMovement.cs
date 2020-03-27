using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    public List<Transform> terrors;

    public float terrorDetectionRadius;
    public float fleeDistance;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        foreach (Transform terror in terrors)
        {
            Vector3 displacement = transform.position - terror.position;
            if (displacement.magnitude < terrorDetectionRadius)
            {
                agent.destination = transform.position + displacement.normalized * fleeDistance;
                // Priority given to running from doggos
                if (terror.CompareTag("Dog"))
                {
                    break;
                }
            }
        }
        
        animator.SetBool("moving", agent.remainingDistance > 0.1);
    }
}
