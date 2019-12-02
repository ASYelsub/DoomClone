using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.Analytics;

public class DoorController : MonoBehaviour
{
    public Transform DoorPos;
    public float Lift;
    public bool liftdoor;
    public float doorTimer;

    public bool inRange; 
    //sets minimum and maximum height of the door
    public float minY ;
    public float maxY ; 


    // Update is called once per frame
    void Update()
    {
        // sets door position as a transform and places a clamp on the Y values. 
       DoorPos.position = new Vector3 (DoorPos.position.x, Mathf.Clamp(DoorPos.position.y, minY, maxY),DoorPos.position.z);

     
           //When player presses space, a message is sent to raise the door. A timer then once raised and when the timer reaches 0 the door closes
        if (Input.GetKey(KeyCode.Space) && inRange)
        {
            liftdoor = true; 
        }
        
        else if (liftdoor)
        {
            transform.position += new Vector3( 0, Lift, 0);
            doorTimer -= Time.deltaTime;
        }
 
        // sets the bool to false once closed so that it can be opened again
        if (doorTimer <= 0)
        {
            liftdoor = false; 
            transform.Translate(0, -Lift, 0);
            inRange = false; 

        }

        if (transform.position.y <= minY)
        {
            doorTimer = 3;
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true; 
        }
       
    }
}

