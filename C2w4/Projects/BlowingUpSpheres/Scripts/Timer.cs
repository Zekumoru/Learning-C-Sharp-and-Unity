using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Fields
    float durationSeconds = 0f;
    float elapsedSeconds = 0f;
    bool running = false;
    bool started = false;

    // Properties
    public float Duration
    {
        set { if (!running) durationSeconds = value; }
    }

    public bool Finished
    {
        get { return !running && started; }
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= durationSeconds)
            {
                running = false;
            }
        }
    }

    public void Run()
    {
        if (durationSeconds > 0f)
        {
            started = true;
            running = true;
            elapsedSeconds = 0f;
        }
    }
}
