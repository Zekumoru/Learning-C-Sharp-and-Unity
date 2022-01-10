using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    #region Fields

    const float ImpulseForceMagnitude = 5.0f;

    GameObject targetPickup;
    bool collecting = false;

    // saved for efficiency
    Rigidbody2D rigidbody2d;
    TheCollector theCollector;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // center the sphere in screen
        Vector3 position = transform.position;
        position.x = 0;
        position.y = 0;
        position.z = 0;
        position = transform.position;

        // saved for efficiency reference
        rigidbody2d = GetComponent<Rigidbody2D>();
        theCollector = Camera.main.GetComponent<TheCollector>();
    }

    // Called when user clicks inside the
    // collider of this game object
    void OnMouseDown()
    {
        // ignore mouse clicks if already collecting
        if (!collecting)
        {
            collecting = true;
            GoToNextPickup();
        }
    }

    // Called when it is inside of another
    // game object's colliders
    // This is used instead of OnCollisionEnter2D
    // because what if it gets triggered by two
    // game objects at the same time?
    void OnTriggerStay2D(Collider2D other)
    {
        // only respond if the collision is
        // with the target pickup
        if (other.gameObject == targetPickup)
        {
            // remove collected pickup from the game
            // then move to the next one
            theCollector.RemovePickup(targetPickup);
            GoToNextPickup();
        }
    }

    public void UpdateTarget(GameObject pickup)
    {
        if (targetPickup == null)
        {
            SetTarget(pickup);
        }
        else
        {
            float targetDistance = GetDistance(targetPickup);
            if (GetDistance(pickup) < targetDistance)
            {
                SetTarget(pickup);
            }
        }
    }
    
    // Finds and goes to the next pickup
    void GoToNextPickup()
    {
        targetPickup = GetClosestPickup();
        if (targetPickup != null)
        {
            GoToTargetPickup();
        }
        else
        {
            rigidbody2d.velocity = Vector3.zero;
            collecting = false;
        }
    }

    GameObject GetClosestPickup()
    {
        List<GameObject> pickups = theCollector.Pickups;
        GameObject closestPickup;
        float closestDistance;
        if (pickups.Count == 0)
        {
            return null;
        }
        else 
        {
            closestPickup = pickups[0];
            closestDistance = GetDistance(closestPickup);
        }

        float distance;
        foreach (GameObject pickup in pickups)
        {
            distance = GetDistance(pickup);
            if (distance < closestDistance)
            {
                closestPickup = pickup;
                closestDistance = distance;
            }
        }

        return closestPickup;
    }

    void SetTarget(GameObject pickup) 
    {
        targetPickup = pickup;
        if (collecting)
        {
            GoToTargetPickup();
        }
    }

    void GoToTargetPickup()
    {
        Vector2 direction = new Vector2(
                targetPickup.transform.position.x - transform.position.x,
                targetPickup.transform.position.y - transform.position.y);
        direction.Normalize();
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.AddForce(direction * ImpulseForceMagnitude,
            ForceMode2D.Impulse);
    }


    float GetDistance(GameObject pickup)
    {
        return Vector3.Distance(transform.position, pickup.transform.position);
    }

    #endregion
}
