using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountMessageEvent : UnityEvent<int>
{
    int count = 0;

    public int Count 
    {
        set { count = value; }
        get { return count; } 
    }
}
