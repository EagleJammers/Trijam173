using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int enemyLimit = 5;
    float timeToCapIncrease = 5f;
    float currentTimeToIncrease;
    int enemyCount;
    public float spawnCD;
    public float nextSpawnTime = 6.0f;
    public float maxSpawnVariability = 8.0f;
    public Vector3 bottomLeft;
    public Vector3 topRight;
    int spawnNext = 0;
    int Kills = 0;
    int KillsNeeded;
    public GameObject Player;
    public GameObject[] Enemies;

    // Start is called before the first frame update
    void Start()
    {
        Begin();
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseDifficulty(Time.deltaTime);
        spawnCD -= Time.deltaTime;
        //Debug.Log("SpawnCD is " + spawnCD);

        if (spawnCD <= 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Debug.Log("Spawning...");
        if (enemyCount < enemyLimit)
        {
            float xCoord = Random.Range(bottomLeft.x, topRight.x);
            float yCoord = Random.Range(bottomLeft.y, topRight.y);
            Vector3 spawnPosition = new Vector3(xCoord, yCoord, 0);

            Object.Instantiate(Enemies[spawnNext], spawnPosition, Quaternion.identity);
            spawnCD = nextSpawnTime + Random.Range(0, maxSpawnVariability);

            enemyCount++;
            Debug.Log("Enemy count is " + enemyCount);
        }
    }

    void IncreaseDifficulty(float timeElapsed)
    {
        if (maxSpawnVariability > 0)
        {
            maxSpawnVariability -= timeElapsed / 40.0f; //8*20 seconds for no variability
            if (maxSpawnVariability < 0)
               maxSpawnVariability = 0;
        }

        if (nextSpawnTime > 0.1)
        {
            nextSpawnTime -= timeElapsed / 15.0f;
            if (nextSpawnTime <= 0.1)
                nextSpawnTime = 0.1f;
        }

        currentTimeToIncrease -= timeElapsed;
        if (currentTimeToIncrease <= 0)
        {
            enemyLimit++;
            Debug.Log("Enemy Limit is " + enemyLimit);
            currentTimeToIncrease = timeToCapIncrease;
        }



 
    }

    void Begin()
    {
        enemyLimit = 5;
        nextSpawnTime = 6.0f;
        maxSpawnVariability = 8.0f;
        enemyCount = 0;
        spawnCD = nextSpawnTime;
        currentTimeToIncrease = timeToCapIncrease;
        Kills = 0;
        KillsNeeded=4;
    }

    void LevelUp()
    {

    }

    public void GainExperience()
    {
        this.Kills++;
        
        if (this.Kills >= this.KillsNeeded)
        {
          LevelUp();
          this.Kills = 0;
          this.KillsNeeded *= 2;
        }
    }

    public void GameOver()
    {

    }
}
