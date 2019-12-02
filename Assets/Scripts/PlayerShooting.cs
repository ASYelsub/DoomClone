using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("System Assign")]
    public HeadBob pistolVSwing;
    public HeadBob pistolHSwing;
    public List<GameObject> enemyList;  // the list of enemy
    public LayerMask obstacleLayer; // the layer of obstacles

    [Header("Auto Assign")]
    public static Guns myGun;
    
    //Gun Data
    private float gunCoolDown;
    private int damage;
    private Sprite idle;
    private Sprite shot;
    private Sprite after;

    //InGameUsing
    private float gunCoolDownSec;

    void Start()
    {
        gunCoolDown = myGun.FireSpeed;
        idle = myGun.idle;
        shot = myGun.shot;
        after = myGun.after;
        gunCoolDownSec = gunCoolDown;
        GetComponent<SpriteRenderer>().sprite = idle;
    }

    private void Update()
    {
        DetectNShoot();
    }

    private void FixedUpdate()
    {
        GunDataUpdate();

        if (gunCoolDownSec > 0)
        {
            gunCoolDownSec -= Time.deltaTime;
        }
    }

    void DetectNShoot(){            //This method is used to detect enemy on different heights
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && gunCoolDownSec <0.01f ){
            gunCoolDownSec = gunCoolDown;            
            StartCoroutine("Shot");

            foreach(GameObject enemy in enemyList){      //Loop every enemy is the list
                if(enemy == null)
                    break;
                Vector3 enemyPos = enemy.transform.position;        //Get their position
                Vector3 myPos = transform.position;                 
                enemyPos.y = 0;                                 // the reason set y to zero is that we want to get a horizontal vector
                myPos.y = 0;

                Vector3 targetDir = enemyPos-myPos;             //this is the vector between enemy and player
                float degreeWithin = 30f/(Vector3.Distance(myPos, enemyPos)); //30 is the k 

                if(Vector3.Angle(targetDir,transform.forward)<degreeWithin){  
                    if(!Physics.Linecast(transform.position,enemy.transform.position,obstacleLayer) ){ // it detects if there are obstacles between them
                        Debug.Log("ShotOnTarget!");
                        enemy.GetComponent<EnemyManager>().HP -= damage;                   
                    }
                }
            }
        }
    }

    private void GunDataUpdate()
    {
        gunCoolDown = myGun.FireSpeed;
        idle = myGun.idle;
        shot = myGun.shot;
        after = myGun.after;
        damage = myGun.Damage;
    }

    IEnumerator Shot()
    {
        SoundMan.me.PistolShoot(transform.position); //for now 
        pistolVSwing.enabled = false;
        pistolHSwing.enabled = false;
        GetComponent<SpriteRenderer>().sprite = shot;

        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().sprite = after;
        
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = idle;
        pistolVSwing.enabled = true;
        pistolHSwing.enabled = true;
    }
}
