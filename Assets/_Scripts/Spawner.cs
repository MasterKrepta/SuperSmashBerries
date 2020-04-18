using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    


    public Transform[] Enemies;
    public Transform[] SpawnPoints;
    public float StartTime = 5f;
    public float delayBetweenSpawn = .75f;
    bool onDelay = false;
    public int numEnemies = 5;
    public int enemiesRemaining = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartWave", StartTime);
    }


    public void StartWave()
    {
        enemiesRemaining = 0;
        InvokeRepeating("SpawnEnemy", delayBetweenSpawn, delayBetweenSpawn);
    }


    void SpawnEnemy()
    {

        if (enemiesRemaining < numEnemies)
        {
            enemiesRemaining++;
            int randEnemy = Random.Range(0, Enemies.Length);
            int randSpawnPoints = Random.Range(0, SpawnPoints.Length);

            Instantiate(Enemies[randEnemy], SpawnPoints[randSpawnPoints].position, Quaternion.identity);
        }
        else
        {
            CancelInvoke();
        }
    }


    public void DestroyEnemy()
    {
        
        enemiesRemaining--;

        if (enemiesRemaining <= 0 )
        {
            IncrementWave();
            print("New Wave");
        }
    }

    void IncrementWave()
    {
        numEnemies =  Mathf.CeilToInt(numEnemies * 1.5f);

        //TODO set up between the waves
        Invoke("StartWave", StartTime);
    }


    
}
