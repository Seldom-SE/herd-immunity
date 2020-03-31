using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkening : MonoBehaviour
{
     public float maxRange = 11;
     public float minRange = 6;
     public float dimmingSlowness = 0.5f;

     public float timerToStart;
 
     private Light lightSource;

     public float timerAdjuster;

     private float checker;
 
     public void Start()
     {
         lightSource = GetComponent<Light>();
         timerAdjuster = 0;
         checker = 0;
     }
 
     public void Update()
     {
         //lightSource.intensity = Mathf.Lerp(maxRange, minRange, Time.time/dimmingSlowness);

         timerToStart = timerToStart - Time.deltaTime;
         if (timerToStart < 0 )
         {
             StartCoroutine("startDimming");
         }

         if (checker == 0){
         timerAdjuster =+ Time.time;
         }
     }

     private void startDimming()
     {
         checker = 1;
         lightSource.intensity = Mathf.Lerp(maxRange, minRange, (Time.time - timerAdjuster)/dimmingSlowness);
     }
 }
