using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobSpawner : MonoBehaviour
{
    // Fields
    [SerializeField]
    GameObject prefabBlueBlob;
    [SerializeField]
    GameObject prefabGreenBlob;
    [SerializeField]
    GameObject prefabPurpleBlob;
    [SerializeField]
    GameObject prefabRedBlob;
    [SerializeField]
    GameObject prefabYellowBlob;

    //[SerializeField]
    //GameObject prefabBlob;

    //// saved for efficiency
    //[SerializeField]
    //Sprite blobSprite0;
    //[SerializeField]
    //Sprite blobSprite1;
    //[SerializeField]
    //Sprite blobSprite2;
    //[SerializeField]
    //Sprite blobSprite3;
    //[SerializeField]
    //Sprite blobSprite4;

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
        switch (prefabNumer)
        {
            case 0:
                Instantiate<GameObject>(prefabBlueBlob, 
                    worldLocation, Quaternion.identity);
                break;
            case 1:
                Instantiate<GameObject>(prefabGreenBlob,
                    worldLocation, Quaternion.identity);
                break;
            case 2:
                Instantiate<GameObject>(prefabPurpleBlob,
                    worldLocation, Quaternion.identity);
                break;
            case 3:
                Instantiate<GameObject>(prefabRedBlob,
                    worldLocation, Quaternion.identity);
                break;
            default:
                Instantiate<GameObject>(prefabYellowBlob,
                    worldLocation, Quaternion.identity);
                break;
        }

        //GameObject blob = Instantiate(prefabBlob) as GameObject;
        //blob.transform.position = worldLocation;

        //// set random sprite for the new blob
        //SpriteRenderer spriteRenderer = blob.GetComponent<SpriteRenderer>();
        //int spriteNumber = Random.Range(0, 5);
        //switch (spriteNumber)
        //{
        //    case 0:
        //        spriteRenderer.sprite = blobSprite0;
        //        break;
        //    case 1:
        //        spriteRenderer.sprite = blobSprite1;
        //        break;
        //    case 2:
        //        spriteRenderer.sprite = blobSprite2;
        //        break;
        //    case 3:
        //        spriteRenderer.sprite = blobSprite3;
        //        break;
        //    default:
        //        spriteRenderer.sprite = blobSprite4;
        //        break;
        //}
    }
}
