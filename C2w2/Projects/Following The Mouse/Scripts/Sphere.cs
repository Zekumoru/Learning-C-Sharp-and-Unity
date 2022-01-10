using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // saved for efficiency
    float colliderHalfWidth;
    float colliderHalfHeight;

    // movement speed
    const float MoveUnitsPerSecond = 3;

    // Awake is called when instantiated
    private void Awake()
    {
        // set up colliders' half sizes
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderHalfWidth = collider.size.x / 2;
        colliderHalfHeight = collider.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        #region Follow Mouse

        //// convert mouse position to world position
        //Vector3 position = Input.mousePosition;
        //position.z = -Camera.main.transform.position.z;
        //position = Camera.main.ScreenToWorldPoint(position);

        #endregion

        #region Move On Keyboard

        // get current position and move according to keyboard
        Vector3 position = transform.position;
        float moveUnitsPerSecondBy = MoveUnitsPerSecond;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // maintain straight and diagonal speed
        if (horizontalInput != 0 && verticalInput != 0)
        {
            moveUnitsPerSecondBy *= Mathf.Cos(Mathf.PI / 4f);
        }

        // handle movement
        if (horizontalInput != 0)
        {
            position.x += horizontalInput * moveUnitsPerSecondBy * Time.deltaTime;
        }
        if (verticalInput != 0)
        {
            position.y += verticalInput * moveUnitsPerSecondBy * Time.deltaTime;
        }

        #endregion

        // gameObject.transform.position = position; OR
        transform.position = position; // because the unity devs decided
                                       // this is a common property to access

        ClampInScreen();
    }

    public void ClampInScreen()
    {
        // clamp position as necessary
        Vector3 position = transform.position;

        // check if it will exit the screen from the left
        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        // check if it will exit the screen from the right
        else if (position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }

        // check if it will exit the screen from the top
        if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
        }
        // check if it will exit the screen from the bottom
        else if (position.y - colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenBottom + colliderHalfHeight;
        }

        // finally, adjust position accordingly
        transform.position = position;
    }
}
