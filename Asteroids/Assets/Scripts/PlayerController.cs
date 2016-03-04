using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    Rigidbody2D rb;         // Allows physics actions to be applied to player 
    float movementSpeed;    // Controls magnitude of force applied to player
    float rotationSpeed;    


	void Start () 
    {
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
    }


    void FixedUpdate()
    {
        // Apply force in the direction the player is currently facing
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(transform.up * movementSpeed);
    }
}
