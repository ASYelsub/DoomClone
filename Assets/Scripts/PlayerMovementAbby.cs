using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAbby : MonoBehaviour
{   
    //public Transform playerTransform;
    Transform cameraTransform;
 //   float timerW,timerA,timerS,timerD = 40f;
    float defaultHeight;
    float walkTime;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        defaultHeight = cameraTransform.parent.position.y;
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
        if(mouseY < 0){
            cameraTransform.parent.position = cameraTransform.parent.position - cameraTransform.parent.forward*0.5f;
        }
        if(Mathf.Abs(mouseY) > 0){
            walkTime += Time.deltaTime;
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log(mouseY);
        }
        
        if(Input.GetKey(KeyCode.W)){
            //Vector3 keyForward = new Vector3(forward);
            cameraTransform.parent.position = cameraTransform.parent.position + cameraTransform.parent.forward;
            walkTime += Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            cameraTransform.parent.position = cameraTransform.parent.position - cameraTransform.parent.forward;
            walkTime += Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            cameraTransform.parent.Rotate(dRotate);
            //cameraTransform.position = cameraTransform.position + cameraTransform.right;
        }
        if(Input.GetKey(KeyCode.A)){
            cameraTransform.parent.Rotate(aRotate);
            //cameraTransform.position = cameraTransform.position - cameraTransform.right;
        }
        cameraTransform.parent.position = new Vector3(cameraTransform.parent.position.x, defaultHeight + Mathf.Cos(walkTime*5f)*0.8f, cameraTransform.parent.position.z);
    }
}
