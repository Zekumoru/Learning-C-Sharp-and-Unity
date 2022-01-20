using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvoker : MonoBehaviour
{
    // Fields
    Timer timer;
    MessageEvent messageEvent;

    // Awake is called when instantiated
    void Awake()
    {
        messageEvent = new MessageEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        // set up timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1f;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // When timer is finished, invoke event then rerun timer
        if (timer.Finished)
        {
            messageEvent.Invoke();
            timer.Run();
        }
    }

    // Adds a listener
    public void AddNoArgumentListener(UnityAction listener)
    {
        messageEvent.AddListener(listener);
    }
}
