using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform cameraTransform;
    public float playerSpeed;
    public float playerDashSpeed;
    public float amp;
    public float freq;
    public float rotateImpact;
    float defaultHeight;
    float walkTime;




    //public GameObject Detect;
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        defaultHeight = cameraTransform.position.y;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position,Detect.transform.position));


        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 mouseRotate = new Vector3(0f,mouseX*10f,0f);
        Vector3 dRotate = new Vector3(0f,rotateImpact,0f);
        Vector3 aRotate = new Vector3(0f,-rotateImpact,0f);
        
        cameraTransform.Rotate(mouseRotate);

        /*if(mouseY > 0){
             cameraTransform.position = cameraTransform.position + cameraTransform.forward*playerDashSpeed;            
        }
        if(mouseY < 0){
             cameraTransform.position = cameraTransform.position - cameraTransform.forward*playerDashSpeed;
        }
        if(Mathf.Abs(mouseY) > 0){
             walkTime += Time.deltaTime;
        }*/
        if(Input.GetKey(KeyCode.W)){
            
            cameraTransform.position = cameraTransform.position + cameraTransform.forward*playerSpeed;
            walkTime += Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            cameraTransform.position = cameraTransform.position - cameraTransform.forward*playerSpeed;
            walkTime += Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            cameraTransform.Rotate(dRotate);
        }
        if(Input.GetKey(KeyCode.A)){
            cameraTransform.Rotate(aRotate);  
        }
        cameraTransform.position = new Vector3(cameraTransform.position.x, defaultHeight + Mathf.Cos(walkTime*freq)*amp, cameraTransform.position.z);
    }
}
