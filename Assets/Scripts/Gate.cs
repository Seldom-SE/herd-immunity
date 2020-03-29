using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    [SerializeField] private float pivotX = 0.85f;
    private Vector3 initialPosition;
    private Vector3 initialEulerAngles;
    
    public bool open;
    
    private Vector3 pivotPoint;
    // Start is called before the first frame update
    void Start() {
        pivotPoint = new Vector3(pivotX, 0.0f, 0.0f);
        initialPosition = transform.position;
        initialEulerAngles = transform.eulerAngles;
    }
    
    void Open(Vector3 playerForward) {
        float rotateAngle = 0.0f;
        if (Mathf.Abs(Vector3.Angle(transform.forward, playerForward)) > 90.0f) {
            rotateAngle = -90.0f;
        } else {
            rotateAngle = 90.0f;
        }
        
        gameObject.transform.RotateAround(transform.TransformPoint(pivotPoint), Vector3.up, rotateAngle);
        open = true;
    }
    
    void Close() {
        // gameObject.transform.Rotate(initialEulerAngles, Space.World);
        gameObject.transform.position = initialPosition;
        gameObject.transform.eulerAngles = initialEulerAngles;
        open = false;
    }
}
