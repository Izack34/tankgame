using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Camera MainCam;
    RaycastHit lookreturn;

    public Transform pointoflook;
    public Transform lookRoot;

    public Transform BarrelRoot;
    public int TurnSpeed;

    private Transform startRotBarrel;

    private Transform startRotTurret;
    public Transform rootofvehicle;

    public Transform lookatobject;
    public Transform Turretbarrel;
    private void Start() {
        startRotBarrel = BarrelRoot;
    }
    void Update()
    {
        lookpoint();
        TurretMove();
        BarrelTarget();
    }


    void lookpoint(){
        /*Vector3 DirectionRay1 = MainCam.transform.TransformDirection(0,0,300);
        Ray ray = new Ray(MainCam.transform, DirectionRay1);

        Debug.DrawRay(MainCam.transform.position, DirectionRay1, Color.red);

        lookRoot.LookAt(ray.GetPoint);

        Vector3 DirectionRay2 = lookRoot.transform.TransformDirection(0,0,300);
    
        Debug.DrawRay(lookRoot.transform.position, DirectionRay2, Color.blue);
        */

        RaycastHit hit;

        if (Physics.Raycast(MainCam.transform.position, MainCam.transform.TransformDirection(0,0,500), out hit, 500))
        {
            Debug.DrawRay(MainCam.transform.position, MainCam.transform.TransformDirection(0,0,500), Color.yellow);
            //Debug.Log("Did Hit");
            pointoflook.position = hit.point;
        }else{

            pointoflook.position = MainCam.transform.position + MainCam.transform.TransformDirection(0,0,500);
 
        }

        lookRoot.LookAt(pointoflook);
        BarrelRoot.LookAt(pointoflook);
        Vector3 DirectionRay2 = lookRoot.transform.TransformDirection(0,0,500);
    
        Debug.DrawRay(lookRoot.transform.position, DirectionRay2, Color.blue);
    }


    void TurretMove(){

        Vector3 DirectionRay = MainCam.transform.TransformDirection(0,0,440);

        Debug.DrawRay(MainCam.transform.position, DirectionRay, Color.red);
        
        float angle = Vector3.SignedAngle(transform.forward, lookRoot.forward , Vector3.up);

        //if(-0.01 > angle ^ angle >  0.01){
        if(angle != 0){
            //transform.rotation *= Quaternion.AngleAxis(angle*TurnSpeed*Time.deltaTime, Vector3.up); 

        }
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
                        Quaternion.Euler(rootofvehicle.eulerAngles.x, lookRoot.eulerAngles.y, rootofvehicle.eulerAngles.z),30 *Time.deltaTime );
    }

    void BarrelTarget(){
        /*Vector3 DirectionRay = MainCam.transform.TransformDirection(0,0,440);


        RaycastHit hit;
        Physics.Raycast(MainCam.transform.position, DirectionRay, out hit, 300);
        Debug.Log(hit.point);

        Debug.DrawRay(Turretbarrel.position, hit.point, Color.blue);
        lookatobject.transform.LookAt(DirectionRay);

        Turretbarrel.rotation = lookatobject.rotation;

        float angle = Vector3.SignedAngle(BarrelRoot.forward, Turretbarrel.forward 
                        , Vector3.right );        

        //Debug.Log(angle);
        
        if(angle != 0){
            
            Turretbarrel.rotation *= Quaternion.AngleAxis(Mathf.Abs(angle)*Time.deltaTime, Vector3.right);      
            //float rotationX = Mathf.Clamp (Turretbarrel.eulerAngles.x, -5.0F, 5.0F);
            //Turretbarrel.rotation = Quaternion.Euler (rotationX, Turretbarrel.eulerAngles.y, Turretbarrel.eulerAngles.z);
        }*/
        Turretbarrel.rotation = Quaternion.RotateTowards(Turretbarrel.rotation, 
                        Quaternion.Euler(BarrelRoot.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z),20 *Time.deltaTime );

    }
}
