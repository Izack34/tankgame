using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turretmove : MonoBehaviour
{
    
    private float movX;
    
    public float yMin = -10;
    public float yMax = 40;
    float xRotation = 0;
    float yRotation = 0;
    public GameObject target;
    public float distance = 10.0f;
    public float sensitivity = 3.0f;
    private Rigidbody rb_c;
    private Vector3 offset;
     

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        rb_c = target.GetComponent<Rigidbody>();
            Cursor.lockState = CursorLockMode.Locked;
            offset = (transform.position - target.transform.position).normalized * distance;
            transform.position = target.transform.position + offset;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        Vector2 controlInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        xRotation += Mathf.Repeat(controlInput.x, 360.0f);
        yRotation -= controlInput.y;
        yRotation = Mathf.Clamp(yRotation, yMin, yMax);
        
        Quaternion newRotation = Quaternion.AngleAxis(xRotation, Vector3.up);
        newRotation *= Quaternion.AngleAxis(yRotation, Vector3.right);

        transform.rotation = newRotation;
        transform.position = target.transform.position - (transform.forward * distance);
        
    }
}
