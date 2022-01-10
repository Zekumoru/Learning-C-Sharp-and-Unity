using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    const float MoveUnitsPerSecond = 3;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // handle movement
        if (horizontalInput != 0)
        {
            position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;
        }
        if (verticalInput != 0)
        {
            position.y += verticalInput * MoveUnitsPerSecond * Time.deltaTime;
        }

        transform.position = position;
    }
}
