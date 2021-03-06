﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    
    public float dmgAmount = 2f;
    Collider col;
    

    private void Start()
    {
        col = GetComponent<Collider>();
        
    }


    private void OnTriggerStay(Collider other)
    {
        var target = other.GetComponentInParent<IDamagable>();
        if (target != null)
        {
            //print(this.name + " caused death");
            
            target.TakeDamage(dmgAmount);
        }

    }

 



}
