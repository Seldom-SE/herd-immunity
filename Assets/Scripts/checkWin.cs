using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWin : MonoBehaviour
{
    private GameObject[] detectors;
    public bool winState = false;
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
                    UnityEngine.Debug.Log("WIN!");
                }
            }
        }
    }
}
