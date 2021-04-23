using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turretmove : MonoBehaviour
{
    private float movX;
    public Transform child_transf;
    
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        float rotX =  Input.GetAxis("Mouse X");
        float rotY =  Input.GetAxis("Mouse Y");
        
        //Debug.Log(rotY);
        transform.Rotate(0f,rotX,0f);

        float minRotation = -45;
        float maxRotation = 45;
        child_transf.Rotate(0f,0f,rotY);

        Vector3 currentRotation = child_transf.localRotation.eulerAngles;
        Debug.Log(currentRotation.z);
        currentRotation.z = Mathf.Clamp(currentRotation.z-360, -20, 30);

        child_transf.localEulerAngles = new Vector3(0f,0f,currentRotation.z);
        //child_transf.localRotation = Quaternion.Euler(currentRotation);
       
    }
}
