using UnityEngine;
using System.Collections;

/*
 * This script is primarily responsible for spawning Enemies. Enemies are 
 * spawned every spawnInterval seconds, in a wave size of waveSize enemies.
 */
public class GameController : MonoBehaviour 
{
    int waveSize;   // The number of enemies spawned for each wave
    float spawnInterval;    // Length of time between waves
    float lastSpawn;    // Time of most recent wave 
    public GameObject enemy;    // Reference to enemy prefab

    void Start()
    {
        waveSize = 5;
        spawnInterval = 7.0f;
        SpawnEnemyWave();
        lastSpawn = Time.time;
    }

    void Update()
    {
        float timeSinceLastSpawn = Time.time - lastSpawn;
        if (timeSinceLastSpawn > spawnInterval)
        {
            SpawnEnemyWave();
            lastSpawn = Time.time;
        }
    }

    void SpawnEnemyWave()
    {
        for (int i = 0; i < waveSize; i++)
            GameObject.Instantiate(enemy);
    }
	
}
