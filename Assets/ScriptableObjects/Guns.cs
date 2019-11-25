using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Guns : ScriptableObject
{
// Sprite of the weapon that is selected by the player 
    public Sprite IdolWeapon;
    //used to create rate of fire for each individual gun
    public float FireSpeed;
    //this bool determines if a gun is automatic because the script for automatic weapons differ from single shot weapons 
    public bool Automatic;
    //number of bullets in each gun// ammo
    public int bulletNumber;
    //how fast each bullet travels
    public float bulletVel;
    //the damage that each gun has on enemies. 
    public int Damage; 

}
