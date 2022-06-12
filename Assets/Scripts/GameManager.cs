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
    int Kills;
    int KillsNeeded;
    public GameObject Player;
    public GameObject[] Enemies;

    // Start is called before the first frame update
    void Start()
    {
        spawnCD = nextSpawnTime;
        currentTimeToIncrease = timeToCapIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseDifficulty(Time.deltaTime);
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        if (enemyCount < enemyLimit)
        {
            float xCoord = Random.Range(bottomLeft.x, topRight.x);
            float yCoord = Random.Range(bottomLeft.y, topRight.y);
            Vector3 spawnPosition = new Vector3(xCoord, yCoord, 0);

            GameObject newEnemy = Object.Instantiate(Enemies[spawnNext], spawnPosition, Quaternion.identity);
            spawnCD = nextSpawnTime + Random.Range(0, maxSpawnVariability);
            enemyCount++;
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
        }

        currentTimeToIncrease -= timeElapsed;
        if (currentTimeToIncrease <= 0)
        {
            enemyLimit++;
            currentTimeToIncrease = timeToCapIncrease;
        }



 
    }

    void Begin()
    {

    }

    void LevelUp()
    {

    }

    void GameOver()
    {

    }
}
