using UnityEngine;
using System.Collections;

/*
 * This script controls behaviour of bullets (projectiles). Causes bullets 
 * to be propelled forward in their current facing direction, and to "die" 
 * after lifespan seconds have passed since instantiation.
 */
public class BulletController : MonoBehaviour 
{
    Rigidbody2D rb;
    float movementSpeed;    // Speed at which the bullet travels
    float timeAlive;        // Time bullet was instantiated
    float lifespan;         // Length of time bullet can be active for

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 3.0f;
        lifespan = 2.0f;
        timeAlive = Time.time;
	}

    // Calculate how long bullet has been active for, and set bullet
    // to inactive if it is longer than the allowed lifespan
    void Update()
    {
        float timeSinceAlive = Time.time - timeAlive;

        if (timeSinceAlive >= lifespan)
            gameObject.SetActive(false);
    }	

    // Propell bullet forward in its current direction
    void FixedUpdate()
    {
        rb.AddForce(transform.up * movementSpeed);
    }
}
