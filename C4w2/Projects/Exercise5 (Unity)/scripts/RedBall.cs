using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The RedBall class inherits from the Ball class.
/// </summary>
public class RedBall : Ball 
{
    // Prints a message
    protected override void PrintMessage()
    {
        print("I'm a red ball!");
    }
}
