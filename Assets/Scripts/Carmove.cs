using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmove : MonoBehaviour
{
    public Transform[] WheeltransformsR;
    public Transform[] WheeltransformsL;
    public WheelCollider[] WheelcollsR;
    public WheelCollider[] WheelcollsL;

    Vector3 pos1;
    Quaternion quat1;
    Vector3 pos2;
    Quaternion quat2;
    
    public Transform CenterofMass;

    public float maxsteerAngle; 
    float troque;
    public float force = 10000f;
    
    private void Start() {
        for( int i = 0; i < WheelcollsR.Length ; i++){
            WheelcollsR[i].ConfigureVehicleSubsteps(5f, 30, 10);
            WheelcollsL[i].ConfigureVehicleSubsteps(5f, 30, 10);
        }
        //this.GetComponent<Rigidbody>().centerOfMass = CenterofMass.position;
    }

    void FixedUpdate()
    {

        Vector2 V = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
        //Debug.Log(V);
        for( int i = 0; i < WheelcollsR.Length ; i++){
            WheelcollsR[i].GetWorldPose(out pos1, out quat1);
            WheelcollsL[i].GetWorldPose(out pos2, out quat2);
            WheeltransformsR[i].position = pos1;
            WheeltransformsL[i].position = pos2;
            //Debug.Log(quat1);
            WheeltransformsR[i].rotation = quat1 * Quaternion.Euler(0,270f,0);
            WheeltransformsL[i].rotation = quat2 * Quaternion.Euler(0,270f,0);
        }

        float m_steeringAngle = maxsteerAngle * V.y ;
        WheelcollsR[1].steerAngle = m_steeringAngle;
        WheelcollsL[0].steerAngle = m_steeringAngle;

        if(V.x == 0){
            for( int i = 0; i < WheelcollsR.Length ; i++){
            //Debug.Log(troque);
            WheelcollsR[i].brakeTorque = 100000;
            WheelcollsL[i].brakeTorque = 100000;
            }
        }else{
            
            troque = Mathf.Clamp(V.x * 30 * force * Time.deltaTime,-100000,100000);
            for( int i = 0; i < WheelcollsR.Length ; i++){
                WheelcollsR[i].motorTorque = troque;
                WheelcollsL[i].motorTorque = troque;
                WheelcollsR[i].brakeTorque = 0;
                WheelcollsL[i].brakeTorque = 0;
            }
        }

        Debug.Log(WheelcollsR[1].rpm +" "+ WheelcollsR[1].brakeTorque);
    }
}
