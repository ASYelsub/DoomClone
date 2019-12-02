using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    [Header("Weapon Lists")]
    public List<Guns> weapon; //The list of weapons as prefabs ,0 is fist, 1 is pistol, 2 is shotgun
    public List<bool> weaponUnlock; //The list of bools whether an weapon is unlocked(picked up)
    
    /*Data for this script only!!!*/
    private int ammo; 
    private int ammo2; 
    private int health; 
    private int armor; 

    
    void Start()
    {

        PlayerShooting.myGun = (Guns)AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Pistol.asset", typeof(Guns));
        ammo = 50;
        ammo2 = 0;
        health = 100;
        armor = 0;

    }

    private void FixedUpdate()
    {
        DataExchange();
        ChangeUI();
    }

    private void Update()
    {
        SwapGun();
    }

    private void DataExchange()
    {
        if (ammo > 200)
            ammo = 200;
        if (ammo2 > 50)
            ammo2 = 50;

        PlayerDataHolder.me.ammo = ammo;
        PlayerDataHolder.me.ammo2 = ammo2;
        PlayerDataHolder.me.health = health;
        PlayerDataHolder.me.armor = armor;
    }

    void ChangeUI()
    {
        UIManager.me.BullEdit(ammo);
        UIManager.me.ShellEdit(ammo2);
        UIManager.me.RocketEdit(0);
        UIManager.me.CellEdit(0);
        UIManager.me.HealthEdit(health);
        UIManager.me.ArmorEdit(armor);
        
        if(PlayerShooting.myGun == weapon[1])
        {
            UIManager.me.CurrentAmmoEdit(ammo);
        }
        else if (PlayerShooting.myGun == weapon[2])
        {
            UIManager.me.CurrentAmmoEdit(ammo2);
        }

    }

    void SwapGun() //By pressing 0 and 1, you can switch between pistol and shotgun.
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponUnlock[0])
        {
            //for Fists
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponUnlock[1])
        {
            PlayerShooting.myGun = weapon[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponUnlock[2])
        {
            PlayerShooting.myGun = weapon[2];
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        print(other.gameObject.name);
        if (other.gameObject.name.Contains("Weapon"))
        {
            if (other.gameObject.name.Contains("Pistol")&&weaponUnlock[1] != true)
            {
                PlayerShooting.myGun = weapon[1];
                weaponUnlock[1] = true;
                ammo += 50;
            }
            if (other.gameObject.name.Contains("Shotgun")&& weaponUnlock[2] != true)
            {
                PlayerShooting.myGun = weapon[1];
                weaponUnlock[2] = true;
                ammo2 += 50;
            }
            Destroy(other.gameObject);
        }


		if (other.gameObject.name.Contains("Armor")) //green armor 100 at most, most armor 1(max 200), blue armor (max 200)
		{
            armor += other.gameObject.GetComponent<GunHealthManager>().thisHealth.restoreHealth;
			Destroy(other.gameObject);
        }

        if (other.gameObject.name.Contains("Health"))
		{
            health += other.gameObject.GetComponent<GunHealthManager>().thisHealth.restoreHealth;
            Destroy(other.gameObject);
		}

        if (other.gameObject.name.Contains("Bullet"))
        {
            if (armor > 0)
            {
                armor -= 10;
            }
            else
            {
                health -= 10;
            }
            health -= 2;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Contains("Ammo"))
        {
            if (other.gameObject.name.Contains("Pistol"))
            {
                if (other.gameObject.name.Contains("clip"))
                {
                    ammo += 5; //Ammo Clip for Pistol
                }
                if (other.gameObject.name.Contains("box"))
                {
                    ammo += 20; //Ammo Clip for Pistol
                }
            }

            if (other.gameObject.name.Contains("Shotgun"))
            {
                if (other.gameObject.name.Contains("clip"))
                {
                    ammo2 += 5; //Ammo Clip for Pistol
                }
                if (other.gameObject.name.Contains("box"))
                {
                    ammo2 += 20; //Ammo Clip for Pistol
                }
            }

            Destroy(other.gameObject);
        }
    }
}
