using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{

	void Start () 
    {
	
	}

	void Update () 
    {
	
	}

    // If GameObject is hit with a projectile, both the GameObject
    // and the Projectile become inactive and the Player gains a point
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Projectile"))
        {
            gameObject.SetActive(false);
            collider.gameObject.SetActive(false);

            // ADD POINTS
        }
    }
}
