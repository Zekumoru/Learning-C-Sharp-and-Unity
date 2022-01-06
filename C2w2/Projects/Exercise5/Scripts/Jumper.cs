using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jumps the game object to the mouse location 
/// when the left mouse button is pressed.
/// </summary>
public class Jumper : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // handle left click
        if (Input.GetMouseButtonDown(0))
        {
            // get and convert mouse position to world location
            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);

            // jump to mouse location and ensure it's within the screen
            gameObject.transform.position = position;
            gameObject.GetComponent<Rock>().ClampInScreen();
        }
    }
}
