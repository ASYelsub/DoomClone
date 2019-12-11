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
    public Sprite[] walk;
    public Sprite[] dying;
    public Sprite[] walkLeft;
    public Sprite[] walkRight; 
    
    private Rigidbody rgbd;
    private bool shootingRunning;
    [Header("Attributes")]
    public float movSpeed;
    public float shootFrequency; //The time interval of shooting a bullet
    public int HP;
	public float randomizer; // random the enemies a little bit
    public bool firstBullet;
    float timer = 0;
    [Header("States")]
    public int state; // 0 idle 1 detected 2 dead
    
    
    [Header("GameObjects")]
    public GameObject bullet;
    public GameObject leftover;
    public GameObject player;
    
 
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rgbd = gameObject.GetComponent<Rigidbody>();
        randomizer = Random.Range(0, 1f);
    }

    void Update()
    {
        if (timer > 4 && timer < 5)
        {
            //StopAllCoroutines();
         
            StartCoroutine(Walking());
        }
        else
        {
            StopCoroutine(Walking());
        }

        if (timer < 2)
        {
          
            StartCoroutine(WalkingLeft());
            
        }
        else
        {
           StopCoroutine(WalkingLeft());
        }
        
        if (timer > 2 && timer < 4)
        {
       
            thisEnemy.flipX = true;
            StartCoroutine(WalkingLeft());
            
        }
        else
        {
            thisEnemy.flipX = false; 
            StopCoroutine(WalkingLeft());
        }

       
        
        
        
        
        if(state == 0)
        {
            StopCoroutine(Shooting());
            // Do Nothing...
        }
        else if(state == 1)
        {
            Movement();
            // shoot once when see player
            if (firstBullet)
            {
                Instantiate(bullet, gameObject.transform.position + new Vector3(6f, 0f, 0f), gameObject.transform.rotation);
                firstBullet = false;
            }
            if (!shootingRunning && timer > 4 && timer < 5)
            {
                StartCoroutine(Shooting());
            }
        }
        if(state == 2 || HP <= 0)
        {
            if(leftover != null)
            Instantiate(leftover, gameObject.transform.position + new Vector3(0f, 0f, 0f), gameObject.transform.rotation);
            FinalSceneUIManager.instance.uisInts[0] += 10; // add 100% to secret entered
            StartCoroutine(Dying());
            Destroy(gameObject);
            
            
        }

      
       

       


        
    }

    void Movement()
    {
        timer += Time.deltaTime;
        transform.LookAt(player.transform);
        if(timer < (2+ randomizer))
            rgbd.AddRelativeForce(Vector3.left * movSpeed);
        if (timer > (2+randomizer) && timer < (4+randomizer))
            rgbd.AddRelativeForce(Vector3.right * movSpeed);
        if (timer > (4+randomizer) && timer < (5+randomizer))
            rgbd.AddRelativeForce(Vector3.forward * movSpeed);
       


        if(timer > (6+randomizer)) //Intentionally leaves 1 second to pause
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
        Instantiate(bullet, gameObject.transform.position + new Vector3(6f,0f,0f), gameObject.transform.rotation);
        shootingRunning = false;
    }


    IEnumerator Walking()
    {
        int i; 
        i = 0; 
        var waitTime = .25f; 
        while (i < walk.Length)
        {

            thisEnemy.sprite = walk[i];
            i++; 
            yield return new WaitForSeconds(waitTime);
            yield return 5; 
           
        }

      //  StartCoroutine(Walking());
    }

    IEnumerator WalkingLeft()
    {
        int i; 
        i = 0; 
        var waitTime = .25f; 
        while (i < walkLeft.Length)
        {

            thisEnemy.sprite = walkLeft[i];
            i++; 
            yield return new WaitForSeconds(waitTime);
            yield return 0; 
           
        }
    }

   

    IEnumerator Dying()

    {
        int i;
        i = 0;
        var waitTime = .25f;
        while (i < dying.Length)
        {
            thisEnemy.sprite = dying[i];
            i++;
            yield return new WaitForSeconds(waitTime); 
            yield return 0;
       // StopCoroutine(Dying());
        }
        
    }
}
