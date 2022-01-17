using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    // Constants
    const int InitialHealth = 100;
    const int DamagePerCollision = 10;
    const float ForceImpulse = 3.0f;

    // Fields
    int health;
    float opacityPerCollision;

    // saved for performance
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    HUD hud;

    // Properties
    public int Health
    {
        set { health = value; }
        get { return health; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // initialization
        audioSource = GetComponent<AudioSource>();
        hud = GameObject.FindGameObjectWithTag("HUD")
            .GetComponent<HUD>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = InitialHealth;
        opacityPerCollision = 
            DamagePerCollision / (float) InitialHealth;

        // get the object moving
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(
            direction * ForceImpulse, ForceMode2D.Impulse);
    }

    // When the ball collides with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // handle collision
        Color color = spriteRenderer.color;
        color.a -= opacityPerCollision;
        spriteRenderer.color = color;
        health -= DamagePerCollision;

        // play sound
        audioSource.Play();

        // update text ui
        hud.AddBounce(1);

        // check if no more health
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
