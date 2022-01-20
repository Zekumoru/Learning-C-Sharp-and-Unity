using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An event listener
/// </summary>
public class Listener : MonoBehaviour
{
	/// <summary>
	/// Use this for initialization
	/// </summary>
	public void Start()
	{
        // add your code here
        EventManager.AddNoArgumentListener(HandleMessageEvent);
        EventManager.AddIntArgumentListener(HandleCountMessageEvent);
	}
	
    /// <summary>
    /// Handles the no argument event
    /// </summary>
    void HandleMessageEvent()
    {
        print("MessageEvent");
    }

    /// <summary>
    /// Handles the one argument event
    /// </summary>
    /// <param name="number">number</number>
    void HandleCountMessageEvent(int number)
    {
        print("CountMessageEvent: " + number);
    }
}
