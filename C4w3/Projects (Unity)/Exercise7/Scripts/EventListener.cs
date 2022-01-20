using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventInvoker eventInvoker = 
            Camera.main.GetComponent<EventInvoker>();
        eventInvoker.AddNoArgumentListener(PrintMessage);
    }

    // Prints a message to console
    public void PrintMessage()
    {
        print("Howdy!");
    }
}
