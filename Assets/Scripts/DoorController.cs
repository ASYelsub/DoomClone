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

    public float minY = 14.6f;

    public float maxY = 40f; 
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
       DoorPos.position = new Vector3 (DoorPos.position.x, Mathf.Clamp(DoorPos.position.y, minY, maxY),DoorPos.position.z);

     
     
        if (Input.GetKey(KeyCode.Space))
        {
            liftdoor = true; 
        }
        
        else if (liftdoor)
        {
            transform.position += new Vector3( 0, Lift, 0);
            doorTimer -= Time.deltaTime;
        }
 
        if (doorTimer <= 0)
        {
            liftdoor = false; 
            transform.Translate(0, -Lift, 0);
            
        }

        if (transform.position.y <= minY)
        {
            doorTimer = 3;
        }
    }
}

