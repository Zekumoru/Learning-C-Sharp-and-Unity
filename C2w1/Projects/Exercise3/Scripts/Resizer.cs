using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The Resizer class will shrink and grow a
 * game object over time.
 */
public class Resizer : MonoBehaviour
{
    // Timer support
    const float TotalResizeSeconds = 5f;
    float elapsedResizeSeconds = 0f;

    // Resizing control
    const float ScaleFactorPerSecond = 1f;
    int scaleFactorSignMultiplier = 1;

    // Update is called once per frame
    void Update()
    {
        // resize
        Vector3 newScale = transform.localScale;
        newScale.x += scaleFactorSignMultiplier * ScaleFactorPerSecond * Time.deltaTime;
        newScale.y += scaleFactorSignMultiplier * ScaleFactorPerSecond * Time.deltaTime;
        transform.localScale = newScale;

        // timer
        elapsedResizeSeconds += Time.deltaTime;
        if (elapsedResizeSeconds >= TotalResizeSeconds)
        {
            elapsedResizeSeconds = 0f;
            scaleFactorSignMultiplier *= -1;
        }
    }
}
