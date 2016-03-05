using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Text lifeText;       // Displays current life count
    int lifeCount;              // The current number of lives the snake has

    void Start()
    {
        score = 0;
        UpdateScore();
        lifeCount = 3;
        UpdateLives();
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

    // Decriment user's lives
    public void RemoveLife()
    {
        if (lifeCount > 0)
        {
            --lifeCount;
            UpdateLives();
        }
        if (lifeCount == 0) // Game is over, restart level
        {
            SceneManager.LoadScene("Main");
        }
    }

    // Update life count display
    void UpdateLives()
    {
        lifeText.text = "Lives: " + lifeCount.ToString();
    }
	
}
