using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    // Fields
    [SerializeField]
    GameObject prefabSphere;

    [SerializeField]
    Sprite blueSphereSprite;
    [SerializeField]
    Sprite purpleSphereSprite;
    [SerializeField]
    Sprite redSphereSprite;

    // spawn control
    const float MinSpawnDelay = 1f;
    const float MaxSpawnDelay = 2f;
    Timer spawnTimer;

    // spawn location support
    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;

    // Start is called before the first frame update
    void Start()
    {
        // save spawn boundaries
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnBlob();

            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    // Spawn a new blob at a random location
    void SpawnBlob()
    {
        // generate random location and create a new blob
        Vector3 location = new Vector3(
            Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        // spawn random blob
        int prefabNumer = Random.Range(0, 5);
        GameObject sphere = Instantiate(prefabSphere) as GameObject;
        sphere.transform.position = worldLocation;

        //// set random sprite for the new blob
        SpriteRenderer spriteRenderer = sphere.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = blueSphereSprite;
            sphere.tag = SphereColor.Blue.ToString();
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = purpleSphereSprite;
            sphere.tag = SphereColor.Purple.ToString();
        }
        else
        {
            spriteRenderer.sprite = redSphereSprite;
            sphere.tag = SphereColor.Red.ToString();
        }
    }
}
