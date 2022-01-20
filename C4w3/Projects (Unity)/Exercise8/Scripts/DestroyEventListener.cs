using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEventListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener(DestroyOnEvent);
    }

    // Destroy this game object when destroy event occurs
    public void DestroyOnEvent()
    {
        Destroy(gameObject);
    }
}
