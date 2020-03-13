using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoard : MonoBehaviour{

    public float boost;
  
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            var force = other.transform.forward * boost;
            other.GetComponent<Rigidbody>().AddForce(force, ForceMode.Acceleration);
            var jumpForce = other.transform.up * 6000;
            var pos = other.GetComponent<SimpleKartController>().jumpAnchor.position;
            other.GetComponent<Rigidbody>().AddForceAtPosition(jumpForce, pos, ForceMode.Impulse);
        }
    }

}
