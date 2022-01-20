using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event Manager handles all events-related code.
/// 
/// Notice the _listener field, you might think we won't need it
/// but the thing is, we need it because we don't know which
/// one, either the _invoker or _listener, will be assigned first.
/// </summary>
public static class EventManager 
{
    static DestroyButton _invoker;
    static UnityAction _listener;

    // Set invoker
    public static void AddInvoker(DestroyButton invoker)
    {
        _invoker = invoker;
        if (_listener != null)
        {
            _invoker.AddDestroyEventListener(_listener);
        }
    }

    // Set listener
    public static void AddListener(UnityAction listener)
    {
        _listener = listener;
        if (_invoker != null)
        {
            _invoker.AddDestroyEventListener(_listener);
        }
    }
}
