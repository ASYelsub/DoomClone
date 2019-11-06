using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [Header("Player Attributes")]
    public int ammo;
    public int ammo2;
    public int health;
    public int armor;
    public GameObject currentWeapon; //The weapon the player is using
    public List<GameObject> weapon; //The list of weapons as prefabs
    public List<bool> weaponUnlock; //The list of bools whether an weapon is unlocked(picked up)
    public PlayerShooting ps; //The ScriptableObject to change

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWeapon!=null)
        ps.myGun = currentWeapon.GetComponent<GunHealthManager>().thisGun;
        SwapGun();
    }

    void SwapGun() //By pressing 0 and 1, you can switch between pistol and shotgun.
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponUnlock[0])
        {
            currentWeapon = weapon[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponUnlock[1])
        {
            currentWeapon = weapon[1];
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
                currentWeapon = weapon[0];
                Destroy(other.gameObject);
            }
            if (other.gameObject.name.Contains("Shotgun"))
            {
                weaponUnlock[1] = true;
                currentWeapon = weapon[1];
                Destroy(other.gameObject);
            }
        }
		if (other.gameObject.name.Contains("Armor"))
		{
            armor += other.gameObject.GetComponent<GunHealthManager>().thisHealth.restoreHealth;
			Destroy(other.gameObject);
		}
		if (other.gameObject.name.Contains("Health"))
		{
            health += other.gameObject.GetComponent<GunHealthManager>().thisHealth.restoreHealth;
            Destroy(other.gameObject);
		}
	}
}
