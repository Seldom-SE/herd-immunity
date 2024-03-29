﻿using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectAnimal : MonoBehaviour
{
    public string animalTag;
    private int animals;
    private GameObject[] animalArr;
    private int maxAnimals;

    public AudioSource AnimalSound;

    public GameObject completedMessage;

    private int hassounded;

    public bool winnable = false;
    // Start is called before the first frame update
    void Start()
    {
        animals = 0;
        animalArr = GameObject.FindGameObjectsWithTag(animalTag);
        maxAnimals = animalArr.Length;
        completedMessage.SetActive(false);
        hassounded = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col){
        UnityEngine.Debug.Log("Something entered");
        if(col.tag == animalTag){
            animals++;

            if(animals == maxAnimals){
                UnityEngine.Debug.Log(animalTag + " win");
                winnable = true;
                completedMessage.SetActive(true);

                if(hassounded == 0){
                AnimalSound.Play();
                }
                hassounded = 1;
            }
        }
    }

    void OnTriggerExit(Collider col){
        UnityEngine.Debug.Log("Something Exited");
        if(col.gameObject.tag == animalTag){
            animals--;
            completedMessage.SetActive(false);
            winnable = false;
        }
    }
}
