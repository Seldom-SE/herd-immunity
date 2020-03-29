using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGate : MonoBehaviour {
    public float distanceToTouch = 2.0f;
    RaycastHit whatIHit;
    [SerializeField] private float raycastYAxisAdd = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        Debug.DrawRay(transform.position + (Vector3.up * raycastYAxisAdd), transform.forward * distanceToTouch, Color.magenta);
        
        if (Physics.Raycast(transform.position + (Vector3.up * raycastYAxisAdd), transform.forward, out whatIHit, distanceToTouch)) {
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
