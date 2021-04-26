using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public Transform[] WheeltransformsR;
    public Transform[] WheeltransformsL;
    public WheelCollider[] WheelcollsR;
    public WheelCollider[] WheelcollsL;

    Vector3 pos1;
    Quaternion quat1;
    Vector3 pos2;
    Quaternion quat2;
    Rigidbody rb;
    float troque;
    public float force = 120000f;
    
    private void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Debug.Log(WheelcollsL[1].rpm);

        Vector2 V = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
        //Debug.Log(V);
        
        for( int i = 0; i < WheelcollsR.Length ; i++){
            WheelcollsR[i].GetWorldPose(out pos1, out quat1);
            WheelcollsL[i].GetWorldPose(out pos2, out quat2);
            //WheeltransformsR[i].position = pos1;
            //WheeltransformsL[i].position = pos2;
            //Debug.Log(quat1);
            WheeltransformsR[i].rotation = quat1 * Quaternion.Euler(0,270f,0);
            WheeltransformsL[i].rotation = quat2 * Quaternion.Euler(0,270f,0);
        }
        if(V.y == 0 && V.x == 0){
            for( int i = 0; i < WheelcollsR.Length ; i++){
                WheelcollsR[i].brakeTorque = 100000;
                WheelcollsL[i].brakeTorque = 100000;   
            }
            return;
        }

        for( int i = 0; i < WheelcollsR.Length ; i++){
                WheelcollsR[i].brakeTorque = 0;
                WheelcollsL[i].brakeTorque = 0;   
        }
        if(V.y < 0){

            rb.AddTorque(transform.up * 40 * -1);
            for( int i = 0; i < WheelcollsR.Length ; i++){

                troque = Mathf.Clamp(20 * force * Time.fixedDeltaTime,-80000,80000);
                WheelcollsR[i].motorTorque = -100000;
                WheelcollsL[i].motorTorque = 100000;
            }

            return;
        }
        if(V.y > 0){
            rb.AddTorque(transform.up * 40 * 1);
            for( int i = 0; i < WheelcollsR.Length ; i++){

                troque = Mathf.Clamp(20 * force * Time.fixedDeltaTime,-80000,80000);
                WheelcollsR[i].motorTorque = 100000;
                WheelcollsL[i].motorTorque = -100000;
            }
            return;
        }

        troque = Mathf.Clamp(V.x * 20 * force * Time.fixedDeltaTime,-80000,80000);
        for( int i = 0; i < WheelcollsR.Length ; i++){
            //Debug.Log(troque);
            WheelcollsR[i].motorTorque = -troque ;
            WheelcollsL[i].motorTorque = -troque;
        }

        //rb.MovePosition(transform.position+ new Vector3(V.x,0,V.y) * Time.deltaTime*50);
    }
}
