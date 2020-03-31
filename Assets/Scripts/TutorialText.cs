using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public float disappearTime;
    
    void Update()
    {
        if (disappearTime < 0f)
        {
            gameObject.SetActive(false);
        }

        disappearTime -= Time.deltaTime;
    }
}
