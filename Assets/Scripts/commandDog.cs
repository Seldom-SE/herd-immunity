using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class commandDog : MonoBehaviour
{
    private GameObject[] dogs;
    private Stack<GameObject> sitStack;
    private Stack<GameObject> followStack;
    //private List<NavMeshAgent> navAgents;
    //private int dogI; // dog index

    // Start is called before the first frame update
    void Start()
    {
        dogs = GameObject.FindGameObjectsWithTag("Dog");
        sitStack = new Stack<GameObject>();
        followStack = new Stack<GameObject>();
        foreach(GameObject dog in dogs)
        {
            followStack.Push(dog);
        }
        //foreach (GameObject dog in dogs)
        //{
        //    navAgents.Add(dog.GetComponent<UnityEngine.AI.NavMeshAgent>());
        //}
        //dogI = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Call dog 1
        {
            //if (followStack.Count > 0)
            //{
            //    GameObject dog = followStack.Pop();
            //    sit dogSit = dog.GetComponent<sit>();
            //    follow dogFollow = dog.GetComponent<follow>();
            //    //if (!dogSit.isSitting)
            //    //{
            //    dogSit.isSitting = true;
            //    dogFollow.isFollowing = false;
            //    //}
            //    sitStack.Push(dog);
            //}

            foreach (GameObject dog in dogs)
            {
                follow follow = dog.GetComponent<follow>();
                if (follow.alphaWolf)
                {
                    follow.goTo(transform.position);
                }
            }
        }
        if (Input.GetButtonDown("Fire2")) // Call dog 2
        {
            //if (sitStack.Count > 0)
            //{
            //    GameObject dog = sitStack.Pop();
            //    sit dogSit = dog.GetComponent<sit>();
            //    follow dogFollow = dog.GetComponent<follow>();
            //    //if (!dogSit.isSitting)
            //    //{
            //    dogSit.isSitting = false;
            //    dogFollow.isFollowing = true;
            //    //}
            //    followStack.Push(dog);
            //}

            foreach (GameObject dog in dogs)
            {
                follow follow = dog.GetComponent<follow>();
                if (!follow.alphaWolf)
                {
                    follow.goTo(transform.position);
                }
            }
        }
    }
}
