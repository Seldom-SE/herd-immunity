using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float distanceToTouch = 2.0f;
    RaycastHit whatIHit;
    
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
    
    void Update() {
        ToggleGate();
    }
    
    void ToggleGate() {
        Debug.DrawRay(transform.position, transform.forward * distanceToTouch, Color.magenta);
        
        if (Physics.Raycast(transform.position, transform.forward, out whatIHit, distanceToTouch)) {
            // Debug.Log("I'm touching a " + whatIHit.collider.gameObject.name + "!");
            if (whatIHit.collider.gameObject.tag == "Gate") {
                // hudCanvas.transform.Find("Prompt").GetComponent<Text>().text = "Press \"E\" to open or close the gate.";
                
                Gate gate = whatIHit.collider.gameObject.GetComponent<Gate>();
                if (Input.GetKeyDown(KeyCode.E)) {
                    if (gate.open) {
                        whatIHit.collider.gameObject.SendMessage("Close");
                    } else {
                        whatIHit.collider.gameObject.SendMessage("Open", transform.forward);
                    }
                }
            }
        } else {
            // hudCanvas.transform.Find("Prompt").GetComponent<Text>().text = 
            // "Get the cart safely to town to win! Use the towers to protect the cart. Hold \"Shift\" to run.";
        }
    }
}
