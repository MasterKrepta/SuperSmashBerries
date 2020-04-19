using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour, IDamagable
{
    public float MaxHealth = 100f;
    public float CurrentHealth;
    public Image imgBaseHealth;

    [SerializeField] bool invincible = false;
    [SerializeField] float resetTime = 1f;


    public void TakeDamage(float dmg)
    {
        if (!invincible)
        {
            invincible = true;
            print("Base takes damage");
            CurrentHealth -= dmg;
            Invoke("ResetInvulnerability", resetTime);
            imgBaseHealth.fillAmount = CurrentHealth / MaxHealth;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthBar();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateHealthBar()
    {
        imgBaseHealth.fillAmount = CurrentHealth / MaxHealth;
    }

    void ResetInvulnerability()
    {
        invincible = false;

    }
}
