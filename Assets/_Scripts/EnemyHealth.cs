using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{

    private void OnEnable()
    {
        GameTriggers.OnWaveEnd += DestroyOnWaveEnd;
    }

    private void OnDisable()
    {
        GameTriggers.OnWaveEnd -= DestroyOnWaveEnd;
    }

    public void TakeDamage(float dmg)
    {

        FindObjectOfType<Spawner>().DestroyEnemy();//TODO this is not the best way to do this
        Destroy(gameObject);
    }

  
    void DestroyOnWaveEnd()
    {
        Destroy(gameObject);
    }
}
