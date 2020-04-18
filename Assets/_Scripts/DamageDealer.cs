using System.Collections;
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


    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponentInParent<IDamagable>();
        if (target != null)
        {
            target.TakeDamage(dmgAmount);
        }
    }

}
