﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    //  public Transform camTransform;
     public GameObject player; 
     
   
    
   
       void Update()
       {
          // transform.rotation = camTransform.rotation; 
      transform.LookAt(player.transform.position);
       }
}
