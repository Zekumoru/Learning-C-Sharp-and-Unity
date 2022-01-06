using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
    // Fields
    static float screenLeft;
    static float screenTop;
    static float screenRight;
    static float screenBottom;

    // Properties
    public static float ScreenLeft
    {
        get { return screenLeft; }
    }

    public static float ScreenTop
    {
        get { return screenTop; }
    }

    public static float ScreenRight
    {
        get { return screenRight; }
    }

    public static float ScreenBottom
    {
        get { return screenBottom; }
    }

    // Methods
    public static void Initialize()
    {
        // get screen size from corners: lower left and upper right
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCorner = new Vector3(0, 0, screenZ);
        Vector3 upperRightCorner = new Vector3(
            Screen.width, Screen.height, screenZ);

        // convert to world coordinates
        lowerLeftCorner = Camera.main.ScreenToWorldPoint(lowerLeftCorner);
        upperRightCorner = Camera.main.ScreenToWorldPoint(upperRightCorner);

        // assign field values
        screenLeft = lowerLeftCorner.x;
        screenRight = upperRightCorner.x;
        screenTop = upperRightCorner.y;
        screenBottom = lowerLeftCorner.y;
    }
}
