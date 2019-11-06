using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [Header("Player Attributes")]
    public int ammo;
    public int health;
    public GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Weapon"))
        {
            currentWeapon = other.gameObject;
            Destroy(other.gameObject);
        }
		if (other.name.Contains("Ammo"))
		{
			ammo += 5;
			Destroy(other.gameObject);
		}
		if (other.name.Contains("Health"))
		{
			health += 5;
			Destroy(other.gameObject);
		}
	}
}
