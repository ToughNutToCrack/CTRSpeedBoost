using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour{

    public Transform kart;
    public float acceleration;
    public float gravity;
    public float steering;

    public Rigidbody rigidBodySphere;

    float speed, currentSpeed, rotate, currentRotate;
    

    void Update(){

        Vector3 updatedPos = new Vector3(rigidBodySphere.transform.position.x, kart.position.y, rigidBodySphere.transform.position.z);
        transform.position = rigidBodySphere.transform.position - new Vector3(0, 0.4f, 0);

        speed = Input.GetAxis("Vertical") * acceleration;
        print(speed);

        if (speed == 0){
            rigidBodySphere.Sleep();
        }
     

        if(Input.GetAxis("Horizontal") != 0){
            int dir = Input.GetAxis("Horizontal") > 0 ? 1: -1;
            float amount = Mathf.Abs(Input.GetAxis("Horizontal"));
            steer(dir, amount);
        }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime *12);
        speed = 0;
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime *4);
        rotate = 0;
    }
    
    void FixedUpdate(){
       rigidBodySphere.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
        

        // rigidBodySphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime *5);

        // RaycastHit hit;
        // Physics.Raycast(transform.position, Vector3.down, out hit, 2);
        // kart.up = Vector3.Lerp(kart.up, hit.normal, Time.deltaTime * 8);
        // kart.Rotate(0, transform.eulerAngles.y, 0);
    }

    void steer(int direction, float amount){
        rotate = steering * direction * amount;
    }
}
