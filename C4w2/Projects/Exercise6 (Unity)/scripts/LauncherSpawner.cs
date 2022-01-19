using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns a launcher every five seconds.
/// When all types of launcher have spawned,
/// stop spawning.
/// </summary>
public class LauncherSpawner : MonoBehaviour
{
    // Launcher prefabs
    [SerializeField]
    GameObject prefabChainsawLauncher;
    [SerializeField]
    GameObject prefabPirateLauncher;
    [SerializeField]
    GameObject prefabZombieLauncher;

    // Fields
    int nextTypeOfLauncher = 0;
    GameObject spawnedLauncher = null;

    // Timer support
    Timer spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        // set timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 5f;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // spawn launcher until all types have spawned
        if (spawnTimer.Finished)
        {
            // destroy previous launcher
            if (spawnedLauncher != null)
            {
                Destroy(spawnedLauncher);
            }

            // spawn a new launcher
            if (nextTypeOfLauncher < 3)
            {
                GameObject launcherToSpawn;
                if (nextTypeOfLauncher == 0)
                {
                    launcherToSpawn = prefabChainsawLauncher;
                }
                else if (nextTypeOfLauncher == 1)
                {
                    launcherToSpawn = prefabPirateLauncher;
                }
                else
                {
                    launcherToSpawn = prefabZombieLauncher;
                }

                spawnedLauncher = Instantiate<GameObject>(launcherToSpawn,
                    Vector2.zero, Quaternion.identity);
                nextTypeOfLauncher++;
                spawnTimer.Run();
            }
        }
    }
}
