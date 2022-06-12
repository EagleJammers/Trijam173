using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int enemyLimit;
    public float spawnCD;
    public float nextSpawnTime = 3.0f;
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
        float xCoord = Random.Range(bottomLeft.x, topRight.x);
        float yCoord = Random.Range(bottomLeft.y, topRight.y);
        Vector3 spawnPosition = new Vector3(xCoord, yCoord, 0);

        GameObject newEnemy = Object.Instantiate(Enemies[spawnNext],spawnPosition,Quaternion.identity);
        spawnCD = nextSpawnTime;
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
