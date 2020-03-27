using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class follow : MonoBehaviour
{
    public bool isFollowing;
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        animator.SetBool("moving", agent.remainingDistance > 0.5);
    }
}
