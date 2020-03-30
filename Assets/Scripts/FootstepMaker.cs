using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepMaker : MonoBehaviour
{
    public CharacterController cc;

    public AudioSource soundsz;
    void Start () 
    {
        cc = GetComponent<CharacterController>();
    }
 
     void Update()
     {
          if (cc.isGrounded == true && cc.velocity.magnitude > 2f && soundsz.isPlaying == false)
        {
            soundsz.Play();
        }

     }
}
