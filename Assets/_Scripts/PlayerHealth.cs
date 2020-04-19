using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public float MaxHealth = 100f;
    public float CurrentHealth;

    [SerializeField] bool invincible = false;
    [SerializeField] float resetTime = 1f;

    private float flashTime = .2f;
    [SerializeField] Color[] originals = new Color[50];
    [SerializeField] Color HitColor = Color.red;

    public void TakeDamage(float dmg)
    {
        if (!invincible)
        {
            invincible = true;
            print("Player takes damage");
            CurrentHealth--;
            Invoke("ResetInvulnerability", resetTime);

            if (CurrentHealth <= 0)
            {
                GameTriggers.OnWaveEnd();
                //todo kill player gameobject saftley
                //this.gameObject.SetActive(false);
            }
            StartCoroutine(Flash());
        }
      
    }

    // Start is called before the first frame update
    void Start()
    {
        GetOriginalColors();
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(2);
        }
    }

    IEnumerator Flash()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.color = HitColor;
        }

        yield return new WaitForSeconds(flashTime);
        foreach (Renderer r in renderers)
        {
            if (r != null)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].material.color = originals[i];
                }

            }
        }
    }

    void GetOriginalColors()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            originals[i] = renderers[i].material.color;
        }
    }

    void ResetInvulnerability()
    {
        invincible = false;

    }
}
