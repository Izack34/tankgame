using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Camera View;
    
    void Start()
    {
        
    }
    /*
    // Update is called once per frame
    void Update()
    {
        float rotX =  Input.GetAxis("Mouse X");
        float rotY =  Input.GetAxis("Mouse Y");

        transform.Rotate(0f,rotX,rotY);

     rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null){
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX
                                                , -cameraRotationLimit 
                                                , cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX,0f,0f);
        }
    }
    */
}
