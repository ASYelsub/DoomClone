﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    //public Transform playerTransform;
    Transform cameraTransform;
    float timerW,timerA,timerS,timerD = 40f;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 mouseRotate = new Vector3(0f,mouseX*10f,0f);
        Vector3 dRotate = new Vector3(0f,10f,0f);
        Vector3 aRotate = new Vector3(0f,-10f,0f);
        cameraTransform.parent.Rotate(mouseRotate);

        if(mouseY > 0){
            cameraTransform.parent.position = cameraTransform.parent.position + cameraTransform.parent.forward*0.5f;
        }
        if(mouseY <0){
            cameraTransform.parent.position = cameraTransform.parent.position - cameraTransform.parent.forward*0.5f;
        }

        if(Input.GetKey(KeyCode.W)){
            //Vector3 keyForward = new Vector3(forward);
            cameraTransform.parent.position = cameraTransform.parent.position + cameraTransform.parent.forward;
        }
        /*if(Input.GetKeyUp(KeyCode.W)){
            timerW--;
            if(timerW > 0f){
                cameraTransform.parent.position = cameraTransform.parent.position + cameraTransform.parent.forward;
            }
            else if(timerW <= 0f){
                timerW = 40f;
            }
        }*/
        if(Input.GetKey(KeyCode.S)){
            cameraTransform.parent.position = cameraTransform.parent.position - cameraTransform.parent.forward;
        }
        if(Input.GetKey(KeyCode.D)){
            cameraTransform.parent.Rotate(dRotate);
            //cameraTransform.position = cameraTransform.position + cameraTransform.right;
        }
        if(Input.GetKey(KeyCode.A)){
            cameraTransform.parent.Rotate(aRotate);
            //cameraTransform.position = cameraTransform.position - cameraTransform.right;
        }
    }
}
