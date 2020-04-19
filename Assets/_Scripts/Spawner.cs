using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    public TMP_Text enemiesTxt;
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

    private void OnEnable()
    {
        GameTriggers.OnPlayerAssigned += IncrementWave;
    }

    private void OnDisable()
    {
        GameTriggers.OnPlayerAssigned -= IncrementWave;
    }

    public void StartWave()
    {
        enemiesRemaining = 0;
        UpdateEnemyText();
        InvokeRepeating("SpawnEnemy", delayBetweenSpawn, delayBetweenSpawn);
    }

    //private void Update()
    //{
    //    Time.timeScale = 1;
    //    if (Input.GetKeyDown(KeyCode.Alpha0))
    //    {
    //        int randEnemy = Random.Range(0, Enemies.Length);
    //        Instantiate(Enemies[randEnemy], SpawnPoints[0].position, Quaternion.identity);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        int randEnemy = Random.Range(0, Enemies.Length);
    //        Instantiate(Enemies[randEnemy], SpawnPoints[1].position, Quaternion.identity);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        int randEnemy = Random.Range(0, Enemies.Length);
    //        Instantiate(Enemies[randEnemy], SpawnPoints[2].position, Quaternion.identity);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        int randEnemy = Random.Range(0, Enemies.Length);
    //        Instantiate(Enemies[randEnemy], SpawnPoints[3].position, Quaternion.identity);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        int randEnemy = Random.Range(0, Enemies.Length);
    //        Instantiate(Enemies[randEnemy], SpawnPoints[4].position, Quaternion.identity);
    //    }
    //}


    void SpawnEnemy()
    {
        
        if (enemiesRemaining <= numEnemies)
        {
            //TODO this can cause a bug where we kill someone before the spawning is finished and cause spawing to never end. may not be a problem with the real level design
            enemiesRemaining++;
            
            int randEnemy = Random.Range(0, Enemies.Length);
            int randSpawnPoints = Random.Range(0, SpawnPoints.Length);

            Instantiate(Enemies[randEnemy], SpawnPoints[randSpawnPoints].position, Quaternion.identity);
            UpdateEnemyText();
        }
        else
        {
            CancelInvoke();
        }
    }


    public void DestroyEnemy()
    {
        
        enemiesRemaining--;
        UpdateEnemyText();

        if (enemiesRemaining <= 0 )
        {
            GameTriggers.OnWaveEnd();
            
            print("New Wave");
        }
    }

    void IncrementWave()
    {
        numEnemies =  Mathf.CeilToInt(numEnemies * 1.5f);

        //TODO set up between the waves
        Invoke("StartWave", StartTime);
    }


    void UpdateEnemyText()
    {
        enemiesTxt.text = $"Enemies: { Mathf.Clamp( enemiesRemaining, 0, numEnemies).ToString()}";
    }
    
}
