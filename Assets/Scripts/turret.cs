using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turret : MonoBehaviour
{
    public Camera MainCam;
    RaycastHit lookreturn;

    public Transform pointoflook;
    public Transform lookRoot;

    public Transform BarrelRoot;
    public int TurnSpeed;

    public Image ImageLooking;
    public Transform barrelLookAt;
    private Transform startRotBarrel;

    private Transform startRotTurret;
    public Transform rootofvehicle;

    public Transform lookatobject;
    public Transform Turretbarrel;
    private float xEulerAngle;


    private void Start() {
        startRotBarrel = BarrelRoot;
    }


    void Update()
    {
        SetLookpointOfCamera();
        TurretMove();
        BarrelTarget();
    }


    void SetLookpointOfCamera(){
        

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
    
        //Debug.DrawRay(lookRoot.transform.position, DirectionRay2, Color.blue);
    }


    void TurretMove(){

        Vector3 DirectionRay = MainCam.transform.TransformDirection(0,0,440);

        //Debug.DrawRay(MainCam.transform.position, DirectionRay, Color.red);
        //Debug.Log(lookRoot.forward.y);

        Vector3 lookforward = new Vector3(lookRoot.forward.x , 0 ,lookRoot.forward.z );
        
        float angle = Vector3.SignedAngle(transform.forward, lookforward , Vector3.up);

        Debug.Log(angle);

        if(angle != 0f){
            //transform.rotation *= Quaternion.AngleAxis(angle*TurnSpeed*Time.deltaTime, Vector3.up);
            //transform.Rotate(0,angle,0 ,Space.Self);
            transform.rotation *= Quaternion.AngleAxis(angle * 3 * Time.deltaTime, Vector3.up);
        
        }

        //transform.rotation = Quaternion.RotateTowards(lookRoot.rotation, 
        //                Quaternion.Euler(-90, 0, lookRoot.eulerAngles.z),30 *Time.deltaTime );

    }

    void BarrelTarget(){
        //Debug.Log(BarrelRoot.eulerAngles.x);

        if(BarrelRoot.eulerAngles.x > 180){
            //Debug.Log("wiecej");
            xEulerAngle = Mathf.Clamp(BarrelRoot.eulerAngles.x, 345, 360);
        }else{
            xEulerAngle = Mathf.Clamp(BarrelRoot.eulerAngles.x, 0, 7);
        }
        
        //Debug.Log(xEulerAngle);

        Turretbarrel.rotation = Quaternion.RotateTowards(Turretbarrel.rotation, 
                        Quaternion.Euler(xEulerAngle, transform.eulerAngles.y, transform.eulerAngles.z),20 *Time.deltaTime );

        RaycastHit hit;

        if (Physics.Raycast(Turretbarrel.position, Turretbarrel.TransformDirection(0,0,500), out hit, 500))
        {
            //Debug.DrawRay(Turretbarrel.position, Turretbarrel.TransformDirection(0,0,500), Color.yellow);
            //Debug.Log("Did Hit");
            barrelLookAt.position = hit.point;
        }else{

            barrelLookAt.position = Turretbarrel.position + Turretbarrel.TransformDirection(0,0,500);
 
        }

        Vector3 screenPoint = MainCam.WorldToScreenPoint(barrelLookAt.position);
        ImageLooking.transform.position = screenPoint;
        
    }
}
