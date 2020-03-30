using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LStormShift : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(0, 0, 0.07f);

        
        //Time.timeScale = 4; SPEED UP THE GAME FOR TESTING PURPOSES
    }
}
