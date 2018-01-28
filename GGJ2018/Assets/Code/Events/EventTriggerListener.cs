//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Events;

public class EventTriggerListener : MonoBehaviour
{
    public EventTrigger Event;
    public UnityEvent OnRaise;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }
    private void OnDisable()
    {
        Event.DeregisterListener(this);
    }
}
