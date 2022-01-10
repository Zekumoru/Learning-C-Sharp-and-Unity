using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Processes mouse button inputs
/// </summary>
public class MouseButtonProcessor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabTeddyBear;

    // first frame input support
    bool hasTeddyBearSpawnedPreviousFrame = false;
	bool hasExplodedPreviousFrame = false;

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // spawn teddy bear as appropriate
        if (Input.GetAxis("SpawnTeddyBear") > 0)
        {
            if (!hasTeddyBearSpawnedPreviousFrame)
            {
                SpawnTeddyBear();
                hasTeddyBearSpawnedPreviousFrame = true;
            }
        }
        else
        {
            hasTeddyBearSpawnedPreviousFrame = false;
        }

        // explode teddy bear as appropriate
		if (Input.GetAxis("ExplodeTeddyBear") > 0)
        {
            if (!hasExplodedPreviousFrame)
            {
                ExplodeTeddyBear();
                hasExplodedPreviousFrame = true;
            }
        }
        else
        {
            hasExplodedPreviousFrame = false;
        }
	}

    void SpawnTeddyBear()
    {
        // get mouse location to world location
        Vector3 location = Input.mousePosition;
        location.z = -Camera.main.transform.position.z;
        location = Camera.main.ScreenToWorldPoint(location);

        // spawn bear to mouse location
        Instantiate<GameObject>(prefabTeddyBear, location, Quaternion.identity);
    }

    void ExplodeTeddyBear()
    {
        // get a teddy bear, if none is found, return
        GameObject teddyBear = GameObject.FindGameObjectWithTag("TeddyBear");
        if (teddyBear == null) return;

        // save its location and destroy
        Vector3 location = teddyBear.transform.position;
        Destroy(teddyBear);

        // play explode animation
        Instantiate(prefabExplosion, location, Quaternion.identity);
    }
}
