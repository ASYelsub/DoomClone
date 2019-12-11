using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("System Assign")]
    public HeadBob pistolVSwing;
    public HeadBob pistolHSwing;
    public List<Guns> weapon;
    public List<GameObject> enemyList;  // the list of enemy
    public List<GameObject> barrelList;
    public LayerMask obstacleLayer; // the layer of obstacles
    public Transform weaponCam;
    public Transform mainCam;

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
       // SoundMan.me.MsicFirstLevel(transform.position);
    }

    private void Update()
    {
        DetectNShoot();
    }

    private void FixedUpdate()
    {
        GunDataUpdate();
        Debug.Log(idle);
        if (gunCoolDownSec > 0)
        {
            gunCoolDownSec -= Time.deltaTime;
        }
    }

    void DetectNShoot(){            //This method is used to detect enemy on different heights
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && gunCoolDownSec <0.01f ){
            gunCoolDownSec = gunCoolDown;            
            StartCoroutine("Shot");
            
            foreach (GameObject enemy in enemyList){      //Loop every enemy is the list
                if(enemy == null)
                    break;
                Vector3 enemyPos = enemy.transform.position;        //Get their position
                Vector3 myPos = transform.position;                 
                enemyPos.y = 0;                                 // the reason set y to zero is that we want to get a horizontal vector
                myPos.y = 0;

                Vector3 targetDir = enemyPos-myPos;             //this is the vector between enemy and player
                float degreeWithin = 40f/(Vector3.Distance(myPos, enemyPos)); //30 is the k 

                if(Vector3.Angle(targetDir,transform.forward)<degreeWithin){  
                    if(!Physics.Linecast(transform.position,enemy.transform.position,obstacleLayer) ){ // it detects if there are obstacles between them
                        Debug.Log("ShotOnTarget!");
                        enemy.GetComponent<EnemyManager>().HP -= damage;
                        SoundMan.me.ImpEnemyInjured(enemy.transform.position);
                    }
                }
            }



            foreach (GameObject barrel in barrelList)
            {      //Loop every enemy is the list
                if (barrel == null)
                    break;
                Vector3 barrelPos = barrel.transform.position;        //Get their position
                Vector3 myPos = transform.position;
                barrelPos.y = 0;                                 // the reason set y to zero is that we want to get a horizontal vector
                myPos.y = 0;

                Vector3 targetDir = barrelPos - myPos;             //this is the vector between enemy and player
                float degreeWithin = 40f / (Vector3.Distance(myPos, barrelPos)); //30 is the k 

                if (Vector3.Angle(targetDir, transform.forward) < degreeWithin)
                {
                    if (!Physics.Linecast(transform.position, barrel.transform.position, obstacleLayer))
                    { // it detects if there are obstacles between them
                        Debug.Log("ShotOnTarget!");
                        barrel.GetComponent<BarrelScript>().health -= damage;
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
        Vector3 weaponInto = new Vector3(transform.localPosition.x, .2f, transform.localPosition.z);
        transform.localPosition = weaponInto;
        Vector3 weaponCamInto = new Vector3(0, weaponCam.localPosition.y, weaponCam.localPosition.z);
        weaponCam.localPosition = weaponCamInto;
        Vector3 mainCamInto = new Vector3(mainCam.localPosition.x, .7f, mainCam.localPosition.z);
        mainCam.localPosition = mainCamInto;

        if (myGun == weapon[1])
        {
            if (PlayerDataHolder.me.ammo <= 0)
                yield break;
            PlayerDataHolder.me.ammo--;
            Debug.Log("HAHAHAHAHAHAH");
            SoundMan.me.PistolShoot(transform.position);
        }

        if (myGun == weapon[2])
        {
            if (PlayerDataHolder.me.ammo2 <= 0)
                yield break;
            PlayerDataHolder.me.ammo2--;
            SoundMan.me.ShotgunShoot(transform.position);
        }
         //for now 
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
