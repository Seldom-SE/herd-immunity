using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormGrow : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += new Vector3(0f, 0.018f, 0f);
    }
}
