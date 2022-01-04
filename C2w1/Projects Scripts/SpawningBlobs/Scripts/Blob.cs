using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        const float MinMagnitude = 3.0f;
        const float MaxMagnitude = 5.0f;
        float magnitude = Random.Range(MinMagnitude, MaxMagnitude);

        float angle = Random.Range(0.0f, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // stub!
    }
}
