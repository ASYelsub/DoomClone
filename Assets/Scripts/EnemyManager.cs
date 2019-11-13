using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /*Movement:
    Enemy moves in a sequence that turns left 3 tiles, right 3 tiles, then forward 1 tiles. (Toward the player)
    States:
    Enemy has 3 states, idle and when player is detected, and dead.
    When it is idling, plays an animation.
    When play is detected, shoot toward the player, and also move.
    When it is dead, spawn the ammo gameobject.
    Attributes:
    Speed, shooting frequency, damage, HP.
    Others:
    Enemies does NOT open doors.
    */

    private Rigidbody rgbd;
    private bool shootingRunning;  //If the shooting corotine is in action
    [Header("Attributes")]
    public float movSpeed; //Movement speed
    public float shootFrequency; //The time interval of shooting a bullet
    public int HP; //Health point of the enemy
    float timer = 0;
    [Header("States")]
    public int state; // 0 idle 1 detected 2 dead
    [Header("Animation")]
    public Animation anim; //Animation played for ideling
    [Header("GameObjects")]
    public GameObject bullet;
    public GameObject leftover; //What ever instantiate when player is destoryed
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rgbd = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(state == 0) //The state of ideling
        {
            StopCoroutine(Shooting());
            // Do Nothing...
        }
        else if(state == 1) //The state of moving
        {
            Movement();
            if (!shootingRunning)
            {
                StartCoroutine(Shooting());
            }
        }
        if(state == 2 || HP <= 0) //The state of dying
        {
            if(leftover != null)
            Instantiate(leftover, gameObject.transform.position + new Vector3(0f, 0f, 0f), gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    void Movement() //Controls the movement of the enemy AI
    {
        timer += Time.deltaTime;
        transform.LookAt(player.transform);
        if(timer < 2)
            rgbd.AddRelativeForce(Vector3.left * movSpeed);  //Move Left
        if (timer > 2 && timer < 4)
            rgbd.AddRelativeForce(Vector3.right * movSpeed); //Move Right
        if (timer > 4 && timer < 5)
            rgbd.AddRelativeForce(Vector3.forward * movSpeed); //Move Forward
        if(timer > 6) //Intentionally leaves 1 second to pause (so that the player get the chance to shoot easily)
        {
            timer = 0;
        }
        if (rgbd.velocity.magnitude > 1.5f)
        {
            rgbd.velocity = rgbd.velocity.normalized * 1.5f;
        }
    }

    IEnumerator Shooting() //The corotine for shooting
    {
        shootingRunning = true;
        yield return new WaitForSeconds(shootFrequency);
        Instantiate(bullet, gameObject.transform.position + new Vector3(1f,0f,0f), gameObject.transform.rotation);
        shootingRunning = false;
    }
}
