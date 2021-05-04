using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Camera MainCam;
    RaycastHit lookreturn;

    public Transform rootofvehicle;
    void Start()
    {
        
    }

    void Update()
    {
        //look();
        //syncRot();

    }

    void syncRot(){
        transform.Rotate(rootofvehicle.rotation.x, 0.0f, rootofvehicle.rotation.z, Space.Self);;
    }

    void look(){

        Vector3 DirectionRay = MainCam.transform.TransformDirection(0,0,80);

        //Physics.Raycast(MainCam.transform.position, DirectionRay, out lookreturn, 200);
        //Debug.Log(lookreturn.transform);
        //float angle = Vector3.Angle(new Vector3(0, DirectionRay.y, 0) , transform.right*-1);

        //Vector3 lookPos = DirectionRay - transform.position;


        //lookPos.y = 0;
        //Quaternion rot  = Quaternion.LookRotation(lookPos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 3.0f);
        //Vector3 targetPoint = new Vector3(lookreturn.transform.position.x, transform.position.y, lookreturn.transform.position.z) 
        //                                   - transform.position;
        Debug.DrawRay(transform.position, DirectionRay, Color.red);
        
        Vector3 newDirection = Vector3.RotateTowards(rootofvehicle.right*-1, new Vector3(DirectionRay.x, 0, DirectionRay.z), 2f, 0.0f);

        //Quaternion rotation = Quaternion.Euler (270, 180, newDirection.z);
        //transform.rotation = Quaternion.Euler(rootofvehicle.rotation.x, transform.rotation.y, rootofvehicle.rotation.z);

        Debug.Log(newDirection);
        
        //Debug.Log(angle);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2.0f);
        //Quaternion targetRotation = Quaternion.LookRotation (DirectionRay, new Vector3(0,1,1));
        //Debug.Log(Quaternion.LookRotation(newDirection));

        Quaternion rot = Quaternion.LookRotation(newDirection);
        Quaternion AxisofTurret = new Quaternion(rootofvehicle.rotation.z, rootofvehicle.rotation.x ,  transform.rotation.z ,1);

        //transform.Rotate(0f,angle,0f);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rootofvehicle.rotation, Time.deltaTime * 4.0f);

        transform.rotation = Quaternion.Slerp(rootofvehicle.rotation, rot, Time.deltaTime * 4.0f);

        //transform.rotation = Quaternion.Euler(-rootofvehicle.rotation.eulerAngles.z, transform.rotation.eulerAngles.y, -rootofvehicle.rotation.eulerAngles.x);
    
    }
}
