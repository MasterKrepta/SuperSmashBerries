using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour, IDamagable
{
    public float MaxHealth = 100f;
    public float CurrentHealth;

    public void TakeDamage(float dmg)
    {
        print("Base takes damage");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
