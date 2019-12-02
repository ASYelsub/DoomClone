using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHolder : MonoBehaviour
{
    public static PlayerDataHolder me;

    public int ammo; //pistol ammo, add to bullets
    public int ammo2; //shotgun amo, add to shells
    public int health; //health points, add to health
    public int armor; //armor points, add to health

    public void Awake()
    {
        if (me != null)
        {
            Destroy(gameObject);
            return;
        }
        me = this;
    }
}
