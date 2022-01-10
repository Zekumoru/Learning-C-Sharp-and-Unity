using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
    static float screenTop;
    static float screenBottom;
    static float screenLeft;
    static float screenRight;

    public static float ScreenLeft
    {
        get { return screenLeft; }
    }

    public static float ScreenRight
    {
        get { return screenRight; }
    }

    public static float ScreenBottom
    {
        get { return screenBottom; }
    }

    public static float ScreenTop
    {
        get { return screenTop; }
    }

    public static void Initialize()
    {
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerLocation = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerLocation = new Vector3(
            Screen.width, Screen.height, screenZ);
        lowerLeftCornerLocation = Camera.main.ScreenToWorldPoint(lowerLeftCornerLocation);
        upperRightCornerLocation = Camera.main.ScreenToWorldPoint(upperRightCornerLocation);

        screenTop = upperRightCornerLocation.y;
        screenBottom = lowerLeftCornerLocation.y;
        screenLeft = lowerLeftCornerLocation.x;
        screenRight = upperRightCornerLocation.x;
    }
}
