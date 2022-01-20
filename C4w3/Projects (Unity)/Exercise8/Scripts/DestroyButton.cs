using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyButton : MonoBehaviour
{
    // Fields 
    DestroyEvent destroyEvent = new DestroyEvent();

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddInvoker(this);
    }

    // Invoke the destroy event on menu button click
    public void OnMenuButtonClick()
    {
        destroyEvent.Invoke();
    }

    // Add a destroy event listener
    public void AddDestroyEventListener(UnityAction listener)
    {
        destroyEvent.AddListener(listener);
    }
}
