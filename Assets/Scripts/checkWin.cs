﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWin : MonoBehaviour
{
    private GameObject[] detectors;
    public bool winState = false;

    public AudioSource winSound;

    // Start is called before the first frame update
    void Start()
    {
        detectors = GameObject.FindGameObjectsWithTag("Detector");
    }

    // Update is called once per frame
    void Update()
    {
        if(!winState){
            foreach(GameObject detector in detectors){
                if(detector.GetComponent<detectAnimal>().winnable){
                    winState = true;
                }
                else{
                    winState = false;
                    break;
}
            }
            if(winState){
            UnityEngine.Debug.Log("WIN!");
            winSound.Play();
}
        }
    }
}