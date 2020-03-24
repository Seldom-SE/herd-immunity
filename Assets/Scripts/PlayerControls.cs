using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        // Movement

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontalInput) > 0.001f)
        {
            transform.position += transform.right * Mathf.Sign(horizontalInput) * speed * Time.fixedDeltaTime;
        }
        if (Mathf.Abs(verticalInput) > 0.001f)
        {
            transform.position += transform.forward * Mathf.Sign(verticalInput) * speed * Time.fixedDeltaTime;
        }

        // Camera Movement

        float mouseDX = Input.GetAxis("Mouse X");

        if (Mathf.Abs(mouseDX) > 0.001f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + mouseDX * mouseSensitivity * Time.fixedDeltaTime, transform.eulerAngles.z);
        }
    }
}
