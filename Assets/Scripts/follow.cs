using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class follow : MonoBehaviour
{
    // Determines which whether they're called by right or left click
    public bool alphaWolf;
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
        //if (isFollowing)
        //{
        //    agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        //}
        animator.SetBool("moving", agent.remainingDistance > 0.1f);
    }

    public void goTo (Vector3 pos)
    {
        agent.destination = pos;
    }
}
