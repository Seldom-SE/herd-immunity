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

    public float meanderRadius;
    public int maxIdleTime;
    private int idleTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        bool inShockAndAbsoluteTerror = false;
        foreach (Transform terror in terrors)
        {
            Vector3 displacement = transform.position - terror.position;
            if (displacement.magnitude < terrorDetectionRadius)
            {
                inShockAndAbsoluteTerror = true;
                agent.destination = transform.position + displacement.normalized * fleeDistance;
                // Priority given to running from doggos
                if (terror.CompareTag("Dog"))
                {
                    break;
                }
            }
        }

        bool moving = agent.remainingDistance > 0.1f;
        animator.SetBool("moving", moving);

        if (!inShockAndAbsoluteTerror && !moving)
        {
            idleTimer--;

            if (idleTimer <= 0)
            {
                Vector2 meanderDisp = Random.insideUnitCircle * meanderRadius;
                Vector3 destination = new Vector3(transform.position.x + meanderDisp.x, transform.position.y, transform.position.z + meanderDisp.y);
                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(destination, path);
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    agent.destination = destination;
                    idleTimer = Random.Range(1, maxIdleTime);
                }
            }
        }
    }
}
