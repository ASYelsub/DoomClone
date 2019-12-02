using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    [Header("Player Attributes")]
    public UIManager uiManager;
    public int ammo; //pistol ammo, add to bullets
    public int ammo2; //shotgun amo, add to shells
    public int health; //health points, add to health
    public int armor; //armor points, add to health
    public GameObject currentWeapon; //The weapon the player is using
    public List<GameObject> weapon; //The list of weapons as prefabs
    public List<bool> weaponUnlock; //The list of bools whether an weapon is unlocked(picked up)
    //public PlayerShooting ps; //The ScriptableObject to change
 
  
    // Start is called before the first frame update
    void Start()
    {
        PlayerShooting.myGun = (Guns)AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Pistol.asset", typeof(Guns));
        ammo = PlayerShooting.myGun.bulletNumber;
        //ps = GetComponentInChildren<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWeapon!=null)
        //ps.myGun = currentWeapon.GetComponent<GunHealthManager>().thisGun;
        SwapGun();
        ChangeUI();
    }

    void ChangeUI()
    {

        uiManager.bullText.text = ammo.ToString() + "/50";
        uiManager.shellText.text = ammo2.ToString() + "/50";
        if (currentWeapon == weapon[1] && currentWeapon != null)
        {
            uiManager.ammoText.text = ammo.ToString();
            uiManager.gunText[0].color = Color.yellow;
        }
        else
        {
            uiManager.gunText[0].color = Color.black;
        }

        if (currentWeapon == weapon[2] && currentWeapon != null)
        {
            uiManager.ammoText.text = ammo2.ToString();
            uiManager.gunText[1].color = Color.yellow;
        }
        else
        {
            uiManager.gunText[1].color = Color.black;
        }

        uiManager.healthText.text = health.ToString();
        uiManager.armorText.text = armor.ToString();

    }

    void SwapGun() //By pressing 0 and 1, you can switch between pistol and shotgun.
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponUnlock[0])
        {
         
            currentWeapon = weapon[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponUnlock[1])
        {
            currentWeapon = weapon[2];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.name.Contains("Weapon"))
        {
            if (other.gameObject.name.Contains("Pistol"))
            {
                weaponUnlock[0] = true;
                currentWeapon = weapon[1];
                Destroy(other.gameObject);
            }
            if (other.gameObject.name.Contains("Shotgun"))
            {
                weaponUnlock[1] = true;
                currentWeapon = weapon[2];
                Destroy(other.gameObject);
            }
        }
		if (other.gameObject.name.Contains("Armor"))
		{
            armor += other.gameObject.GetComponent<GunHealthManager>().thisHealth.restoreHealth;
			Destroy(other.gameObject);
            uiManager.ArmorEdit(armor);
        }
		if (other.gameObject.name.Contains("Health"))
		{
            health += other.gameObject.GetComponent<GunHealthManager>().thisHealth.restoreHealth;
            Destroy(other.gameObject);
		}
        if (other.gameObject.name.Contains("Bullet"))
        {
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
        }
    }
}
