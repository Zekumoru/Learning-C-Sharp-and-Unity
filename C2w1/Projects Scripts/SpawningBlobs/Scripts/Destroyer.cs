using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    // timer support
    Timer explodeTimer;

    // Start is called before the first frame update
    void Start()
    {
        explodeTimer = gameObject.AddComponent<Timer>();
        explodeTimer.Duration = 1f;
        explodeTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // check if timer has finished and restart
        if (explodeTimer.Finished)
        {
            explodeTimer.Run();

            // blow up a C4 blob
            GameObject blob = GameObject.FindWithTag("C4Blob");
            if (blob != null)
            {
                Instantiate<GameObject>(prefabExplosion,
                    blob.transform.position, Quaternion.identity);
                Destroy(blob);
            }
        }
    }
}
