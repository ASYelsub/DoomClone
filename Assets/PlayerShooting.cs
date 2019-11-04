using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public List<GameObject> enemyList;
    public LayerMask obstacleLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DetectNShoot();
    }

    void DetectNShoot(){
        
        foreach(GameObject enemy in enemyList){
            Vector3 enemyPos = enemy.transform.position;
            Vector3 myPos = transform.position;

            enemyPos.y = 0;
            myPos.y = 0;

            Vector3 targetDir = enemyPos-myPos;

            if(Vector3.Angle(targetDir,transform.forward)<3f){
                //Debug.Log("Detect!");
                if(!Physics.Linecast(transform.position,enemy.transform.position,obstacleLayer)){
                    Debug.Log("Hit");
                }
            }
        }
    }
}
