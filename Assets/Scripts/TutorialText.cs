using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public float disappearTime;

    public GameObject backdrop;
    
    void Update()
    {
        if (disappearTime < 0f)
        {
            gameObject.SetActive(false);
            Destroy(backdrop);
        }

        disappearTime -= Time.deltaTime;
    }
}
