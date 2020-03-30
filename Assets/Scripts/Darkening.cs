using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkening : MonoBehaviour
{
     public float maxRange = 11;
     public float minRange = 6;
     public float dimmingSlowness = 0.5f;
 
     private Light lightSource;
 
     public void Start()
     {
         lightSource = GetComponent<Light>();
     }
 
     public void Update()
     {
         lightSource.intensity = Mathf.Lerp(maxRange, minRange, Time.time/dimmingSlowness);
     }
 }
