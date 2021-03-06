﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float explodeTime = 2f;
    public float lifeTime = .25f;
    public float dmg = 100f; //Enough to kill everything at once. 
    public GameObject particle;
    
    
    
    Collider collider;

    private void Start()
    {
        
        collider = GetComponent<Collider>();
        collider.enabled = false;
        Invoke("Explode", explodeTime);
    }

    void Explode()
    {
        
        collider.enabled = true;
        GameObject go = Instantiate(particle, transform.position, Quaternion.identity);
        go.GetComponent<AudioSource>().Play();
        Destroy(go, 1f);
        Destroy(this.gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamagable>();
        if (damageable != null)
        {
            damageable.TakeDamage(dmg);
        }
    }

}
