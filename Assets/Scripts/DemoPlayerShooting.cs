using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerShooting : MonoBehaviour
{
    // [Header("Animation Stuff")] 
    // public Animator Shooting; 
    
    
    public HeadBob pistolVSwing;
    public HeadBob pistolHSwing;
    
    public List<GameObject> enemyList;  // the list of enemy
    public LayerMask obstacleLayer; // the layer of obstacles
    // public float gunCoolDown;
    // public Guns myGun; 
    public Sprite idlePistol;
    public Sprite shotPistol;

    public Sprite afterShotPistol;
   
void Start()
{
 
            // Shooting.SetBool("Pistol", false);
        
}
    void Update()
    {
       
       // gunCoolDown = myGun.FireSpeed; 
     
        // if (gunCoolDown > 0)
        // {
        //     gunCoolDown -= Time.deltaTime; 
        //     Shooting.SetBool("Pistol", true);
        // }

        // else
        // {
        //     Shooting.SetBool("Pistol", false);
        // }

        DetectNShoot();
    }

    void DetectNShoot(){            //This method is used to detect enemy on different heights
        
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            StartCoroutine("shot");
            foreach(GameObject enemy in enemyList){      
                          //Loop every enemy is the list
            if(enemy == null)
            {
                break;
            }
            Vector3 enemyPos = enemy.transform.position;        //Get their position
            Vector3 myPos = transform.position;                 

            enemyPos.y = 0;                                 // the reason set y to zero is that we want to get a horizontal vector
            myPos.y = 0;

            Vector3 targetDir = enemyPos-myPos;             //this is the vector between enemy and player
            float degreeWithin = 30f/(Vector3.Distance(myPos, enemyPos)); //30 is the k 
            if(Vector3.Angle(targetDir,transform.forward)<degreeWithin){  //vector3.angle returns the degree between two vectors, in this scenerio,
                                                                //it returns the angle between player and enemy regardless y parameter
                                                                // if it is within 3 degrees, 

                if(!Physics.Linecast(transform.position,enemy.transform.position,obstacleLayer) ){ 
                        // it detects if there are obstacles between them
                    Debug.Log("Detect");
                    // enemy.GetComponent<EnemyManager>().HP -= myGun.Damage;
                        
                       // Update();
                    
                    
                }
                
            }
            }
        
        
        }
    }

    IEnumerator shot()
    {
        pistolVSwing.enabled = false;
        pistolHSwing.enabled = false;
        GetComponent<SpriteRenderer>().sprite = shotPistol;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().sprite = afterShotPistol;
        
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = idlePistol;
        pistolVSwing.enabled = true;
        pistolHSwing.enabled = true;
    }
}
