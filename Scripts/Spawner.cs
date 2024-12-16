using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    public GameObject[] enemyPrefab;
    public float minimumSpawnTime = 1f;    
    public float maximumSpawnTime = 10f;  
    public int maxEnemySpawns = 2;

    [SerializeField]
    float timeUntilNextSpawn;
    [SerializeField]
    float spawnsCount;


    void Awake()
    {
        spawnsCount = 0;
        SetTimeUntilSpawn();        
    }

    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;        

        if (timeUntilNextSpawn <= 0)
        {
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], transform.position, Quaternion.identity);
            spawnsCount += 1;
            if (spawnsCount == maxEnemySpawns)
            {
                Destroy(gameObject);
            }
            SetTimeUntilSpawn();
        }       
    }

    void SetTimeUntilSpawn()
    {
        timeUntilNextSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime+1);
    }
}
