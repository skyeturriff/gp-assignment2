using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * This script is primarily responsible for spawning Enemies. Enemies are 
 * spawned every spawnInterval seconds, in a wave size of waveSize enemies.
 */
public class GameController : MonoBehaviour 
{
    int waveSize;               // The number of enemies spawned for each wave
    float spawnInterval;        // Length of time between waves
    float lastSpawn;            // Time of most recent wave 
    public GameObject enemy;    // Reference to enemy prefab
    public Text scoreText;      // Displays current score to user
    int score;                  // Holds the user's current score

    void Start()
    {
        score = 0;
        UpdateScore();
        waveSize = 5;
        spawnInterval = 7.0f;
        SpawnEnemyWave();
        lastSpawn = Time.time;
    }

    // Check time since last enemy wave spawn
    void Update()
    {
        float timeSinceLastSpawn = Time.time - lastSpawn;
        if (timeSinceLastSpawn > spawnInterval)
        {
            SpawnEnemyWave();
            lastSpawn = Time.time;
        }
    }

    // Spawn a new wave of Enemy objects
    void SpawnEnemyWave()
    {
        for (int i = 0; i < waveSize; i++)
            GameObject.Instantiate(enemy);
    }

    // Increment the user's score
    public void AddPoint()
    {
        ++score;
        UpdateScore();
    }

    // Update score display
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
	
}
