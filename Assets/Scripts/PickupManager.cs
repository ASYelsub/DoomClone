using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    [Header("Weapon Lists")]
    public List<Guns> weapon; //The list of weapons as prefabs ,0 is fist, 1 is pistol, 2 is shotgun
    public List<bool> weaponUnlock; //The list of bools whether an weapon is unlocked(picked up)
    public SpriteRenderer weaponImage;

    public bool acidStart; //For the corotine that starts the damage of the player.

    public float timePassed;

    /*Data for this script only!!!*/
    //private int ammo; 
    //private int ammo2; 
    //private int health; 
    //private int armor; 
    private bool endSOnce = true;
    
    void Start()
    {

        //PlayerShooting.myGun = Resources.Load<Guns>("Pistol"); //(Guns)AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Pistol.asset", typeof(Guns));
        PlayerDataHolder.me.ammo = 50;
        PlayerDataHolder.me.ammo2 = 0;
        PlayerDataHolder.me.health = 100;
        PlayerDataHolder.me.armor = 0;
        PlayerShooting.myGun = weapon[1];
        weaponImage.sprite = PlayerShooting.myGun.idle;
        UIManager.me.UnlockPistol();
    }

    private void FixedUpdate()
    {
        //DataExchangeOut();
        ChangeUI();
        if (PlayerDataHolder.me.health < 0 && endSOnce )
        {
            FinalSceneUIManager.instance.canShow = true;
            endSOnce = false;
        }
    }

    private void Update()
    {
        SwapGun();
        timePassed += Time.deltaTime;
       
    }

    //private void LateUpdate()
    //{
    //    DataExchangeIn();
    //}

    //private void DataExchangeIn()
    //{
    //    ammo = PlayerDataHolder.me.ammo;
    //    ammo2  = PlayerDataHolder.me.ammo2;
    //    health = PlayerDataHolder.me.health;
    //    armor = PlayerDataHolder.me.armor;
    //}

    //private void DataExchangeOut()
    //{
    //    if (ammo > 200)
    //        ammo = 200;
    //    if (ammo2 > 50)
    //        ammo2 = 50;

    //    PlayerDataHolder.me.ammo = ammo;
    //    PlayerDataHolder.me.ammo2 = ammo2;
    //    PlayerDataHolder.me.health = health;
    //    PlayerDataHolder.me.armor = armor;
    //}

    void ChangeUI()
    {
        UIManager.me.BullEdit(PlayerDataHolder.me.ammo);
        UIManager.me.ShellEdit(PlayerDataHolder.me.ammo2);
        UIManager.me.RocketEdit(0);
        UIManager.me.CellEdit(0);
        UIManager.me.HealthEdit(PlayerDataHolder.me.health);
        UIManager.me.ArmorEdit(PlayerDataHolder.me.armor);
        
        if(PlayerShooting.myGun == weapon[1])
        {
            UIManager.me.CurrentAmmoEdit(PlayerDataHolder.me.ammo);
        }
        else if (PlayerShooting.myGun == weapon[2])
        {
            UIManager.me.CurrentAmmoEdit(PlayerDataHolder.me.ammo2);
        }

    }

    void SwapGun() //By pressing 0 and 1, you can switch between pistol and shotgun.
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponUnlock[0])
        {
            //for Fists
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponUnlock[1])
        {
            PlayerShooting.myGun = weapon[1];
            weaponImage.sprite = PlayerShooting.myGun.idle;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponUnlock[2])
        {
            PlayerShooting.myGun = weapon[2];
            weaponImage.sprite = PlayerShooting.myGun.idle;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        print(other.gameObject.name);
        if (other.gameObject.name.Contains("Weapon"))
        {
            FinalSceneUIManager.instance.uisInts[1] += 10; // add 10% to items gained
            if (other.gameObject.name.Contains("Pistol"))
            {
                UIManager.me.UnlockPistol();
                PlayerDataHolder.me.ammo += 50;
                if(weaponUnlock[1] != true)
                {
                    PlayerShooting.myGun = weapon[1];
                    weaponUnlock[1] = true;
                    PlayerShooting.myGun = weapon[1];
                    weaponImage.sprite = PlayerShooting.myGun.idle;
                    SoundMan.me.WeaponPickUp(transform.position);
                }
                else
                {
                    SoundMan.me.ItemPickUp(transform.position);
                }
            }
            if (other.gameObject.name.Contains("Shotgun"))
            {
                UIManager.me.UnlockShotgun();
                PlayerDataHolder.me.ammo2 += 50;
                if(weaponUnlock[2] != true)
                {
                    PlayerShooting.myGun = weapon[1];
                    weaponUnlock[2] = true;
                    PlayerShooting.myGun = weapon[2];
                    weaponImage.sprite = PlayerShooting.myGun.idle;
                    SoundMan.me.WeaponPickUp(transform.position);
                }
                else
                {
                    SoundMan.me.ItemPickUp(transform.position);
                }
            }
            Destroy(other.gameObject);
        }


		if (other.gameObject.name.Contains("Armor")) //green armor 100 at most, most armor 1(max 200), blue armor (max 200)
		{
            FinalSceneUIManager.instance.uisInts[1] += 10; // add 10% to items gained
            if (other.gameObject.name.Contains("Green")&& PlayerDataHolder.me.armor<=100)
            {
                PlayerDataHolder.me.armor = 100;
			    Destroy(other.gameObject);
                SoundMan.me.PowerUp(transform.position);
            }
            if (other.gameObject.name.Contains("Blue"))
            {
                PlayerDataHolder.me.armor = 200;
                Destroy(other.gameObject);
                SoundMan.me.PowerUp(transform.position);
            }
            if (other.gameObject.name.Contains("Bonus"))
            {
                PlayerDataHolder.me.armor +=5;
                Destroy(other.gameObject);
                SoundMan.me.ItemPickUp(transform.position);
            }

        }

        if (other.gameObject.name.Contains("Health"))
		{
            FinalSceneUIManager.instance.uisInts[1] += 10; // add 10% to items gained
            if (other.gameObject.name.Contains("Bonus"))
            {
                PlayerDataHolder.me.health += 5;
            }
            if (other.gameObject.name.Contains("Kits"))
            {
                PlayerDataHolder.me.health = 100;
            }

            Destroy(other.gameObject);
            SoundMan.me.ItemPickUp(transform.position);
        }

        if (other.gameObject.name.Contains("Bullet"))
        {
            FinalSceneUIManager.instance.uisInts[1] += 10; // add 10% to items gained
            if (PlayerDataHolder.me.armor > 0)
            {
                PlayerDataHolder.me.armor -= 10;
                SoundMan.me.PlayerInjured(transform.position);
            }
            else
            {
                PlayerDataHolder.me.health -= 10;
                SoundMan.me.PlayerInjured(transform.position);
            }
            //PlayerDataHolder.me.health -= 2;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Contains("Ammo"))
        {
            FinalSceneUIManager.instance.uisInts[1] += 10; // add 10% to items gained
            if (other.gameObject.name.Contains("Pistol"))
            {
                if (other.gameObject.name.Contains("Clip"))
                {
                    PlayerDataHolder.me.ammo += 5; //Ammo Clip for Pistol
                    SoundMan.me.ItemPickUp(transform.position);
                }
                if (other.gameObject.name.Contains("Box"))
                {
                    PlayerDataHolder.me.ammo += 20; //Ammo Clip for Pistol
                    SoundMan.me.ItemPickUp(transform.position);
                }
            }

            if (other.gameObject.name.Contains("Shotgun"))
            {
                if (other.gameObject.name.Contains("Clip"))
                {
                    PlayerDataHolder.me.ammo2 += 5; //Ammo Clip for Pistol
                    SoundMan.me.ItemPickUp(transform.position);
                }
                if (other.gameObject.name.Contains("box"))
                {
                    PlayerDataHolder.me.ammo2 += 20; //Ammo Clip for Pistol
                    SoundMan.me.ItemPickUp(transform.position);
                }
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.name.Contains("SecretCollider"))
        {
            FinalSceneUIManager.instance.uisInts[0] += 10; // add 10% to enemies killed
        }

        if (other.gameObject.name.Contains("FinalEnters"))
        {
            FinalSceneUIManager.instance.uisInts[3] = (int)timePassed; // counting the time since the begining
            FinalSceneUIManager.instance.canShow = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Acid"))
        {
            if(acidStart == false)
            StartCoroutine(acidDamange());
        }
    }

    IEnumerator acidDamange()
    {
        acidStart = true;
        yield return new WaitForSeconds(1);
        PlayerDataHolder.me.health -= 10;
        SoundMan.me.PlayerInjured(transform.position);
        acidStart = false;
    }
}
