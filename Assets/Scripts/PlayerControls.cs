using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float speed;

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontalInput) > 0.001f)
        {
            transform.position += transform.right * Mathf.Sign(horizontalInput) * speed;
        }
        if (Mathf.Abs(verticalInput) > 0.001f)
        {
            transform.position += transform.forward * Mathf.Sign(verticalInput) * speed;
        }
    }
}
