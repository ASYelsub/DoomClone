using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Guns : ScriptableObject
{
    public GameObject GunFire; 
    public Sprite SelectedWeapon;
    public AudioSource AS;
    public AudioClip Shot; 
    public float FireSpeed;
    public bool Automatic;
    public float Spread;
    public int bulletNumber;
    public float bulletVel;
    public int Damage; 

}
