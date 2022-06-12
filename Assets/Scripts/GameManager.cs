using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int enemyLimit;
    public float spawnCD;
    public float nextSpawnTime = 3.0f;
    int spawnNext = 0;
    int Kills = 0;
    int KillsNeeded;
    public GameObject Player;
    public GameObject TestSpawn;
    public GameObject[] Enemies;

    // Start is called before the first frame update
    void Start()
    {
        spawnCD = nextSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject newEnemy = Object.Instantiate(Enemies[spawnNext], TestSpawn.transform);
        spawnCD = nextSpawnTime;
    }

    void Begin()
    {

    }

    void LevelUp()
    {

    }

    public void GainExperience()
    {
        this.Kills++;
    }

    public void GameOver()
    {

    }
}
