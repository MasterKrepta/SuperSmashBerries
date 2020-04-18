using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public float MaxHealth = 100f;
    public float CurrentHealth;

    public void TakeDamage(float dmg)
    {
        CurrentHealth--;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
