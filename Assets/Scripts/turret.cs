using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Camera MainCam;
    RaycastHit lookreturn;

    public int TurnSpeed;

    public Transform rootofvehicle;

    public Transform Turretbarrel;
    void Update()
    {
        look();
        BarrelTarget();
    }


    void look(){

        Vector3 DirectionRay = MainCam.transform.TransformDirection(0,0,140);

        Debug.DrawRay(MainCam.transform.position, DirectionRay, Color.red);

        float angle = Vector3.SignedAngle(transform.forward, DirectionRay , Vector3.up);

        if(-1 > angle ^ angle >  1){
            transform.rotation *= Quaternion.AngleAxis(angle*TurnSpeed*Time.deltaTime, Vector3.up); 
            
        }

    }

    void BarrelTarget(){
        Vector3 DirectionRay = MainCam.transform.TransformDirection(0,0,1);


        Debug.DrawRay(Turretbarrel.position, DirectionRay, Color.blue);

        float angle = Vector3.SignedAngle(Turretbarrel.forward, 
                        DirectionRay, Vector3.right);        

        Debug.Log(angle);
        if(angle != 0){

            Turretbarrel.rotation *= Quaternion.AngleAxis(angle*Time.deltaTime, Vector3.right);      
            //float rotationX = Mathf.Clamp (Turretbarrel.eulerAngles.x, -5.0F, 5.0F);
            //Turretbarrel.rotation = Quaternion.Euler (rotationX, Turretbarrel.eulerAngles.y, Turretbarrel.eulerAngles.z);
        }

    }
}
