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
    public SpriteRenderer thisEnemy; 
    private Rigidbody rgbd;
    private bool shootingRunning;
    [Header("Attributes")]
    public float movSpeed;
    public float shootFrequency; //The time interval of shooting a bullet
    public int HP;
    float timer = 0;
    [Header("States")]
    public int state; // 0 idle 1 detected 2 dead
    
    
    [Header("GameObjects")]
    public GameObject bullet;
    public GameObject leftover;
    public GameObject player;
    
    [Header("Walking")]
    public Sprite leftStep; 
    public Sprite inMotion;
    public Sprite rightStep;
   
    [Header("Dying Sprites")] 
    public Sprite Falling; 
    public Sprite fallingTwo;
    public Sprite fallingThree;
    public Sprite fallingFour;
    public Sprite fallingFive;
    
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rgbd = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(state == 0)
        {
            StopCoroutine(Shooting());
            // Do Nothing...
        }
        else if(state == 1)
        {
            Movement();
            if (!shootingRunning)
            {
                StartCoroutine(Shooting());
            }
        }
        if(state == 2 || HP <= 0)
        {
            if(leftover != null)
            Instantiate(leftover, gameObject.transform.position + new Vector3(0f, 0f, 0f), gameObject.transform.rotation);
            Destroy(gameObject);
            // Starts the dying sprites
            StartCoroutine(Dying());
        }
    }

    void Movement()
    {
        timer += Time.deltaTime;
        transform.LookAt(player.transform);
        if(timer < 2)
            rgbd.AddRelativeForce(Vector3.left * movSpeed);
        if (timer > 2 && timer < 4)
            rgbd.AddRelativeForce(Vector3.right * movSpeed);
        if (timer > 4 && timer < 5)
            rgbd.AddRelativeForce(Vector3.forward * movSpeed);
        // walking forward sprites 
            StartCoroutine(Walking());
          if(timer > 6) //Intentionally leaves 1 second to pause
        {
            timer = 0;
        }
        if (rgbd.velocity.magnitude > 1.5f)
        {
            rgbd.velocity = rgbd.velocity.normalized * 1.5f;
        }
    }

    IEnumerator Shooting()
    {
        shootingRunning = true;
        yield return new WaitForSeconds(shootFrequency);
        Instantiate(bullet, gameObject.transform.position + new Vector3(1f,0f,0f), gameObject.transform.rotation);
        shootingRunning = false;
    }


    IEnumerator Walking()
    {
        var waitTime = 1.0f; 
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            thisEnemy.sprite = leftStep;
            yield return new WaitForSeconds(waitTime);
            thisEnemy.sprite = inMotion;
            yield return new WaitForSeconds(waitTime);
            thisEnemy.sprite = rightStep;
            yield return new WaitForSeconds(waitTime);
            thisEnemy.sprite = inMotion;

        }
    }

    IEnumerator Dying()

    {
        var waitTime = .25f;
        yield return new WaitForSeconds(waitTime);
        thisEnemy.sprite = Falling;
        yield return new WaitForSeconds(waitTime);
        thisEnemy.sprite = fallingTwo; 
        yield return new WaitForSeconds(waitTime);
        thisEnemy.sprite = fallingThree;
        yield return new WaitForSeconds(waitTime);
        thisEnemy.sprite = fallingFour;
        yield return new WaitForSeconds(waitTime);
        thisEnemy.sprite = fallingFive;
    }
}
