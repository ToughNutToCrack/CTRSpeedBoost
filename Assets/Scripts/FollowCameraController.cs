using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraController : MonoBehaviour{
    
    public GameObject[] cameraList;
    private int currentCamera;

    void Update () {
        if (Input.GetKeyUp(KeyCode.Space)){
            
            if (currentCamera + 1 < cameraList.Length){
                cameraList[currentCamera].gameObject.SetActive(false);
                currentCamera ++;
                cameraList[currentCamera].gameObject.SetActive(true);
            }
            else {
                cameraList[currentCamera].gameObject.SetActive(false);
                currentCamera = 0;
                cameraList[currentCamera].gameObject.SetActive(true);
            }
        }
    }
}
