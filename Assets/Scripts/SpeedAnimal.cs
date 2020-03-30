using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAnimal : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedForAnimal;
    void Start()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = speedForAnimal;
    }

}
