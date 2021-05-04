using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmove : MonoBehaviour
{
    public Transform[] WheeltransformsR;
    public Transform[] WheeltransformsL;
    public WheelCollider[] WheelcollsR;
    public WheelCollider[] WheelcollsL;


    public float MaxEngineRPM = 4000.0f;
    public float MinEngineRPM = 1000.0f;
    private float EngineRPM = 0.0f;
    public float[] GearRatio;

    int currentGear = 1;
    Vector3 pos1;
    Quaternion quat1;
    Vector3 pos2;
    Quaternion quat2;
    
    Vector2 V;
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
        V = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));

        gearShift();
        Steer();
        AddToruque();
        //Debug.Log(V);

    }

    void gearShift(){
            EngineRPM = (WheelcollsR[0].rpm + WheelcollsL[0].rpm)/GearRatio[currentGear];
            Debug.Log(EngineRPM);
            Debug.Log(currentGear);

            if ( EngineRPM >= MaxEngineRPM ) {
                if(currentGear <= GearRatio.Length-2){
                    currentGear += 1;
                }  
            }
    
            if ( EngineRPM <= MinEngineRPM ) {
                if(currentGear >= 1){
                    currentGear -= 1;
                }
            }

    }

    void Steer(){
        //Vector2 V = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
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
        WheelcollsR[0].steerAngle = m_steeringAngle;
        WheelcollsL[0].steerAngle = m_steeringAngle;
        WheelcollsR[1].steerAngle = m_steeringAngle/2;
        WheelcollsL[1].steerAngle = m_steeringAngle/2;

    }

    void AddToruque(){
        //Vector2 V = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
        if(V.x == 0){
            for( int i = 0; i < WheelcollsR.Length ; i++){
            //Debug.Log(troque);
            WheelcollsR[i].brakeTorque = 100000;
            WheelcollsL[i].brakeTorque = 100000;
            }
        }else{
            //Debug.Log("wad");
            //Debug.Log(troque);
            troque = Mathf.Clamp(V.x * 30 * force * Time.deltaTime,-100000,100000);
            for( int i = 0; i < WheelcollsR.Length ; i++){
                WheelcollsR[i].motorTorque = troque / GearRatio[currentGear];
                WheelcollsL[i].motorTorque = troque / GearRatio[currentGear];
                WheelcollsR[i].brakeTorque = 0;
                WheelcollsL[i].brakeTorque = 0;
            }
        }

        //Debug.Log(WheelcollsR[1].rpm +" "+ WheelcollsR[1].brakeTorque);
    }

}