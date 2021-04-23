using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Camera MainCam;
    RaycastHit lookreturn;
    void Start()
    {
        
    }

    void Update()
    {
        look();

    }

    void look(){

        RaycastHit lookreturn;
        Vector3 DirectionRay = MainCam.transform.TransformDirection(0,0,1);

        Physics.Raycast(MainCam.transform.position, DirectionRay, out lookreturn, 200);

        transform.LookAt(lookreturn.transform);
    }
}
