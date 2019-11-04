﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public List<GameObject> enemyList;  // the list of enemy
    public LayerMask obstacleLayer; // the layer of obstacles
    void FixedUpdate()
    {
        DetectNShoot();
    }

    void DetectNShoot(){            //This method is used to detect enemy on different heights
        
        foreach(GameObject enemy in enemyList){                //Loop every enemy is the list
            Vector3 enemyPos = enemy.transform.position;        //Get their position
            Vector3 myPos = transform.position;                 

            enemyPos.y = 0;                                 // the reason set y to zero is that we want to get a horizontal vector
            myPos.y = 0;

            Vector3 targetDir = enemyPos-myPos;             //this is the vector between enemy and player

            if(Vector3.Angle(targetDir,transform.forward)<3f){  //vector3.angle returns the degree between two vectors, in this scenerio,
                                                                //it returns the angle between player and enemy regardless y parameter
                                                                // if it is within 3 degrees, 

                if(!Physics.Linecast(transform.position,enemy.transform.position,obstacleLayer)){ // it detects if there are obstacles between them
                    Debug.Log("Hit");
                }
            }
        }
    }
}
