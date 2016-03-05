using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    GameController gameController;  // Reference to the GameController object in this scene
    Rigidbody2D rb;         // Allows physics actions to be applied to player 
    float movementSpeed;    // Controls magnitude of force applied to player
    float rotationSpeed;
    public GameObject bullet;   // Reference to bullet prefab player will fire

	void Start () 
    {
        // Set gameController to GameController object active in scene
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 5.0f;
        rotationSpeed = 3.0f;
	}

    void Update()
    {
        // Check for change in player's direction (rotation)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Rotate the player left or right
        transform.Rotate(transform.forward, -moveHorizontal * rotationSpeed); 

        // Check for fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnedBullet = GameObject.Instantiate(bullet);
            spawnedBullet.transform.position = transform.position;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }

    void FixedUpdate()
    {
        // Apply force in the direction the player is currently facing
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(transform.up * movementSpeed);
    }

    // If GameObject collides with an Enemy, the Enemy dissapears
    // and the Player loses a life, until no lives are left
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.SetActive(false);
            gameController.RemoveLife();
        }
    }
}
