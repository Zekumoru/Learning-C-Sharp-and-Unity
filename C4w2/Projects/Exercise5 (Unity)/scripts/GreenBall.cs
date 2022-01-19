using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GreenBall class inherits from the Ball class
/// </summary>
public class GreenBall : Ball
{
    // Start is called before the first frame update
    protected override void Start()
    {
        impulseVector.y = impulseVector.x * -1;
        impulseVector.x = 0;
        base.Start();
    }

    // Prints a message
    protected override void PrintMessage()
    {
        print("I'm a green ball!");
    }
}
