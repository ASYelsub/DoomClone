using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMan : MonoBehaviour
{
    public static SoundMan me;
    
    [Header("Audio Setting")]
    public int maxAudioSouces;
    public AudioSource sourcePrefab;
    AudioSource[] sources;
    
    [Header("Player")]
    public AudioClip hittingGround; 
    public AudioClip doorActivison; //not the sound of the door, the sound of player
    public AudioClip playerInjured;
    public AudioClip[] playerDeath;
    private int lastPlayerDeath;
    
    [Header("Player Weapons")]
    public AudioClip pistol;
    public AudioClip shotgun;
    public AudioClip fistHitting;

    [Header ("Gun Enemy")]
    public AudioClip[] gunEnemySight;
    private int lastGunEnemySight;
    public AudioClip[] gunEnemyDeath;
    private int lastGunEnemyDeath;
    public AudioClip gunEnemySG;
    public AudioClip gunEnemyPistol;
    public AudioClip gunEnemyInjured;

    [Header("Imp Enemy(Fireball)")]
    public AudioClip[] impEnemySight;
    private int lastImpEnemySight;
    public AudioClip[] impEnemyDeath;
    private int lastImpEnemyDeath;
    public AudioClip impEnemyAttack;
    public AudioClip impEnemyInjured;

    [Header("Diegetic Sound")]
    public AudioClip liftStart;
    public AudioClip liftStop;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip switchOn;
    public AudioClip switchOff;
    public AudioClip barrelExplode;
    public AudioClip itemPickUp;
    public AudioClip weaponPickUp;
    public AudioClip powerUp;

    [Header ("Music")]
    public AudioClip msicFirstLevel;
    public AudioClip msicSecondLevel;
    
    private void Awake()
    {
        if(me != null)
        {
            Destroy(gameObject);
            return;
        }
        me = this;

        sources = new AudioSource[maxAudioSouces];
        for (int i = 0; i < maxAudioSouces; i++)
        {
            sources[i] = Instantiate(sourcePrefab);
        }
    }

    /*Player Sound Function */
    public void PlayerHittingGround(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = hittingGround;
        source.transform.position = pos;
        source.Play();
    }

    public void PlayerActivateDoors(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = doorActivison;
        source.transform.position = pos;
        source.Play();
    }
    public void PlayerInjured(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = playerInjured;
        source.transform.position = pos;
        source.Play();
    }
    public void PlayerDeath(Vector3 pos){
        AudioSource source = GetSource();
        int clipNum = GetClipIndex(playerDeath.Length,lastPlayerDeath);
        lastPlayerDeath = clipNum;
        source.clip = playerDeath[clipNum];
        source.transform.position = pos;
        source.Play();
    }

    /*Player use guns */
    public void PistolShoot(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = pistol;
        source.transform.position = pos;
        source.Play();
    }

    public void ShotgunShoot(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = shotgun;
        source.transform.position = pos;
        source.Play();
    }

    public void FistHit(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = fistHitting;
        source.transform.position = pos;
        source.Play();
    }
    /*Enemy use guns */
    public void GunEnemySight(Vector3 pos){
        AudioSource source = GetSource();
        int clipNum = lastGunEnemySight;
        lastGunEnemySight = clipNum;
        source.clip = gunEnemySight[clipNum];
        source.transform.position = pos;
        source.Play();
    }
    public void GunEnemyDeath(Vector3 pos){
        AudioSource source = GetSource();
        int clipNum = lastGunEnemyDeath;
        lastGunEnemyDeath = clipNum;
        source.clip = gunEnemyDeath[clipNum];
        source.transform.position = pos;
        source.Play();
    }
    public void GunEnemySG(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = gunEnemySG;
        source.transform.position = pos;
        source.Play();
    }
    public void GunEnemyPistol(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = gunEnemyPistol;
        source.transform.position = pos;
        source.Play();
    }
    public void GunEnemyInjured(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = gunEnemyInjured;
        source.transform.position = pos;
        source.Play();
    }
    /*Imp enemy uses fireball */
    public void ImpEnemySight(Vector3 pos){
        AudioSource source = GetSource();
        int clipNum = lastImpEnemySight;
        lastImpEnemySight = clipNum;
        source.clip = impEnemySight[clipNum];
        source.transform.position = pos;
        source.Play();
    }
    public void ImpEnemyDeath(Vector3 pos){
        AudioSource source = GetSource();
        int clipNum = lastImpEnemyDeath;
        lastImpEnemyDeath = clipNum;
        source.clip = impEnemyDeath[clipNum];
        source.transform.position = pos;
        source.Play();
    }
    public void ImpEnemyAttack(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = impEnemyAttack;
        source.transform.position = pos;
        source.Play();
    }
    public void ImpEnemyInjured(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = impEnemyInjured;
        source.transform.position = pos;
        source.Play();
    }

    /*Diegetic sound (environment) */
    public void LiftStart(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = liftStart;
        source.transform.position = pos;
        source.Play();
    }
    public void LiftStop(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = liftStop;
        source.transform.position = pos;
        source.Play();
    }
    public void DoorOpen(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = doorOpen;
        source.transform.position = pos;
        source.Play();
    }
    public void DoorClose(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = doorClose;
        source.transform.position = pos;
        source.Play();
    }
    public void SwitchOn(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = switchOn;
        source.transform.position = pos;
        source.Play();
    }
    public void SwitchOff(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = switchOff;
        source.transform.position = pos;
        source.Play();
    }
    public void BarrelExplode(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = barrelExplode;
        source.transform.position = pos;
        source.Play();
    }

    public void ItemPickUp(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = itemPickUp;
        source.transform.position = pos;
        source.Play();
    }
    public void WeaponPickUp(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = weaponPickUp;
        source.transform.position = pos;
        source.Play();
    }
    public void PowerUp(Vector3 pos){
        AudioSource source = GetSource();
        source.clip = powerUp;
        source.transform.position = pos;
        source.Play();
    }

    /*Music stuff */
    public void MsicFirstLevel(Vector3 player){
        AudioSource source = GetSource();
        source.clip = msicFirstLevel;
        source.spread = 180;
        source.transform.position = player;
        source.loop = true;
        source.Play();
    }
    public void MsicSecondLevel(){
        AudioSource source = GetSource();
        source.clip = msicSecondLevel;
        source.spread = 180;
        source.transform.position = new Vector3 (0,0,0);
        source.Play();
    }

    /*This is the part of getting prefab */  
    int GetClipIndex(int clipNum, int lastPlayed)
    {
        int num = Random.Range(0, clipNum);
        while (num == lastPlayed)
            num = Random.Range(0, clipNum);
        return num;
    }

    AudioSource GetSource()
    {
        for (int i = 0; i < maxAudioSouces ; i++)
        {
            if (!sources[i].isPlaying)
                return sources[i];

        }

        return sources[0];
    }


}


