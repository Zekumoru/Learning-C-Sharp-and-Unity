using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Fields

    // timer duration
    float totalSeconds = 0f;

    // timer execution
    float elapsedSeconds = 0f;
    bool running = false;

    // support for Finished property
    bool started = false;

    #endregion

    #region Properties

    /// <summary>
    /// Sets the duration of the timer.
    /// The duration can only be set if the timer is not currently running.
    /// </summary>
    /// <value>duration</value>
    public float Duration
    {
        set { if (!running) totalSeconds = value; }
    }

    /// <summary>
    /// Gets the state of the timer if it is finished or not.
    /// Also, returns false if the timer has not started yet.
    /// </summary>
    /// <value>true if finished; otherwise, false.</value>
    public bool Finished
    {
        get { return started && !running; }
    }

    /// <summary>
    /// Gets the state of the timer if it is still running or not.
    /// </summary>
    /// <value>true if running; otherwise, false.</value>
    public bool Running
    {
        get { return running; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame.
    /// Also, this updates the timer and ends after it is finished.
    /// </summary>
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }

    /// <summary>
    /// Runs the timer.
    /// Only run the timer if the duration set is above 0.
    /// </summary>
    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0f;
        }
    }

    #endregion
}