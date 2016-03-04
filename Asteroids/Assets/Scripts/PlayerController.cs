using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    Rigidbody2D rb;         // Allows physics actions to be applied to player 
    float movementSpeed;    // Controls magnitude of force applied to player

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 5.0f;
	}

	
	void Update () 
    {
        // Check for change in player's direction (rotation)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Rotate the player left or right
        transform.Rotate(transform.forward, -moveHorizontal);
    }


    void FixedUpdate()
    {
        // Apply force (accelleration/decelleration) to player
        // in the direction the player is currently facing
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(transform.up * movementSpeed);
        
        //else if (Input.GetKey(KeyCode.DownArrow))
        //    rb.AddForce(-transform.up * (movementSpeed / 2.0f));
    }
}
