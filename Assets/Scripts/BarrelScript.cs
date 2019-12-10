﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public int health;
    public GameObject pS;

    private void Start()
    {
        health = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SoundMan.me.BarrelExplode(transform.position);
            Instantiate(pS, transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
