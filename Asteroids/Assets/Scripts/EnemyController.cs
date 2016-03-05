using UnityEngine;
using System.Collections;

/*
 * This script controls behaviour of Enemies. On instantiation, they
 * are given a random direction and speed that is maintained for the
 * duration of their lifetime. Enemies are killed by projectiles.
 */
public class EnemyController : MonoBehaviour 
{
    Vector2 screenSize;     // Holds screen bounds information
    float maxSpeed;         // Range for random speed of Enemy motion
    float minSpeed;
    Rigidbody2D rb;

    void Start()
    {
        // Position Enemy randomly within screen bounds
        screenSize.y = Camera.main.orthographicSize;
        screenSize.x = screenSize.y * Camera.main.aspect;
        transform.position = new Vector2(
            Random.Range(-screenSize.x, screenSize.x), 
            Random.Range(-screenSize.y, screenSize.y)
        );

        // Set Enemy in motion at random speed
        rb = GetComponent<Rigidbody2D>();
        minSpeed = 2.0f;
        maxSpeed = 20.0f;
        rb.AddForce(transform.position * Random.Range(minSpeed, maxSpeed));
    }

	void Update () 
    {
	
	}

    void FixedUpdate()
    {

    }

    // If GameObject is hit with a projectile, both the GameObject
    // and the Projectile are destroyed and the Player gains a point
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);

            // ADD POINTS
        }
    }
}
