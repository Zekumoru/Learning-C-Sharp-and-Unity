using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // prefabs
    [SerializeField]
    GameObject prefabRock;

    // sprites
    [SerializeField]
    Sprite rockSprite0;

    [SerializeField]
    Sprite rockSprite1;

    [SerializeField]
    Sprite rockSprite2;

    // timer support
    const float SpawnTime = 1f;
    Timer spawnTimer;

    // location
    float spawnLocationX;
    float spawnLocationY;

    // Start is called before the first frame update
    void Start()
    {
        // set spawn location
        spawnLocationX = Screen.width / 2;
        spawnLocationY = Screen.height / 2;

        // add timer and run
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = SpawnTime;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            // spawn rock if rock count < 3
            // NOT = 3 because the third rock hasn't spawned yet
            if (GameObject.FindGameObjectsWithTag("Rock").Length < 3)
            {
                spawnRock();
            }

            // restart timer
            spawnTimer.Run();
        }
    }

    void spawnRock()
    {
        // create spawn location and create rock
        Vector3 location = new Vector3(
            spawnLocationX,
            spawnLocationY,
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject rock = Instantiate(prefabRock) as GameObject;
        rock.transform.position = worldLocation;

        // change rock color
        SpriteRenderer spriteRenderer = rock.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = rockSprite0;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = rockSprite1;
        }
        else
        {
            spriteRenderer.sprite = rockSprite2;
        }
    }
}
