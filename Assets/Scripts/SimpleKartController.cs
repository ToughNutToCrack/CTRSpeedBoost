using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
     
public class SimpleKartController : MonoBehaviour {
    public List<AxleInfo> axleInfos; 
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float topSpeed = 25;

    public GameObject smoke;
    public GameObject turbo;
    public Transform jumpAnchor;

    Rigidbody rb;
     
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // public void ApplyLocalPositionToVisuals(WheelCollider collider)
    // {
    //     if (collider.transform.childCount == 0) {
    //         return;
    //     }
     
    //     Transform visualWheel = collider.transform.GetChild(0);
     
    //     Vector3 position;
    //     Quaternion rotation;
    //     collider.GetWorldPose(out position, out rotation);
     
    //     visualWheel.transform.position = position;
    //     visualWheel.transform.rotation = rotation;
    // }

    public void Update(){
        if( Mathf.Round(rb.velocity.magnitude) > topSpeed ){
            smoke.SetActive(false);
            turbo.SetActive(true);
        }else{
            smoke.SetActive(true);
            turbo.SetActive(false);
        }
    }
     
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
     
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            // ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            // ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}
