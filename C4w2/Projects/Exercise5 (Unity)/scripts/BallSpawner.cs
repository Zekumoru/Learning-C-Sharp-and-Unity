using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Periodically spawns a ball
/// </summary>
public class BallSpawner : MonoBehaviour
{
    // Prefabs
    [SerializeField]
    GameObject whiteBall;
    [SerializeField]
    GameObject redBall;
    [SerializeField]
    GameObject greenBall;

    // constants
    const float SPAWN_TIMER_DURATION = 0.5f;

    // Timer support
    Timer spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = SPAWN_TIMER_DURATION;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            // spawn a random ball
            int randomBall = Random.Range(0, 3);
            if (randomBall == 0)
            {
                Instantiate(whiteBall);
            }
            else if (randomBall == 1)
            {
                Instantiate(greenBall);
            }
            else
            {
                Instantiate(redBall);
            }

            spawnTimer.Run();
        }
    }
}
