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


    void StartWave()
    {
        enemiesRemaining = numEnemies;
        for (int i = 0; i < numEnemies; i++)
        {
            //todo add delay to prevent spawning on top of each other
                int randEnemy = Random.Range(0, Enemies.Length);
                int randSpawnPoints = Random.Range(0, SpawnPoints.Length);

                Instantiate(Enemies[randEnemy], SpawnPoints[randSpawnPoints].position, Quaternion.identity);
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
