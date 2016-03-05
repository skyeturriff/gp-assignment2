using UnityEngine;
using System.Collections;

/*
 * This script controls behaviour when a GameObject goes over the edge of
 * the screen. It causes the GameObject to wrap around to the opposite screen 
 * boundary, while maintaining current direction.
 */
public class BoundaryWrapper : MonoBehaviour 
{
    Camera mainCamera;      // Camera to query screen bounds
    Vector2 screenSize;     // Holds screen bounds information

	void Start () 
    {
        mainCamera = Camera.main;
        screenSize.y = mainCamera.orthographicSize;     // half screen height
        screenSize.x = screenSize.y * mainCamera.aspect;    // half screen width
	}


    // Check if GameObject is out of screen bounds; if so, transport 
    // it to the opposite side of the screen
	void Update () 
    {
        if (transform.position.x > screenSize.x)
            transform.position = new Vector3(-screenSize.x, transform.position.y);

        else if (transform.position.x < -screenSize.x)
            transform.position = new Vector3(screenSize.x, transform.position.y);

        else if (transform.position.y > screenSize.y)
            transform.position = new Vector3(transform.position.x, -screenSize.y);

        else if (transform.position.y < -screenSize.y)
            transform.position = new Vector3(transform.position.x, screenSize.y);
	}
}
