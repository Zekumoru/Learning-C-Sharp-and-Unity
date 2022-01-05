using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // jump location support
    const float minX = -4.8f, maxX = 4.8f, minY = -2.5f, maxY = 2.5f;

    // timer support
    const float TotalJumpDelaySeconds = 1f;
    float elapsedJumpDelaySeconds = 0f;

    // Update is called once per frame
    void Update()
    {
        // update timer and check if it's done
        elapsedJumpDelaySeconds += Time.deltaTime;
        print("Delta Time: " + Time.deltaTime);
        print("Elapsed: " + elapsedJumpDelaySeconds);

        /**
         * Basically what's happening (as how I understand it currently),
         * Time.deltaTime returns the interval in seconds from the last frame
         * to the next frame. It doesn't make any sense, does it?
         * 
         * Based on my analysis, each frame will take some tiny, tiny, tiny second
         * to render then afterward it will move to the next frame. This tiny, tiny,
         * tiny second is what we call delta time.
         * 
         * Why do we need to add deltaTime? So that we will know, if a second has
         * passed, 2 seconds, a minute, etc.
         * 
         * Since computers may be slow or fast, how much time they take to render
         * one frame will always vary. Hence, if we then take this to our advantage,
         * we can know how much in total have passed rendering x frames if we put
         * it in a variable.
         */

        if (elapsedJumpDelaySeconds >= TotalJumpDelaySeconds)
        {
            print("[IF] Delta Time: " + Time.deltaTime);
            print("[IF] Elapsed: " + elapsedJumpDelaySeconds);
            elapsedJumpDelaySeconds = 0f;

            // randomize location
            Vector2 position = transform.position;
            position.x = Random.Range(minX, maxX);
            position.y = Random.Range(minY, maxY);
            transform.position = position;
        }
    }
}
