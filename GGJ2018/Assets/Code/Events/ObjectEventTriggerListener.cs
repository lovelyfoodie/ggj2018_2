//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using UnityEngine;

public class ObjectEventTriggerListener : MonoBehaviour
{
    public ObjectEventTrigger Event;
    public ObjectUnityEvent OnRaise;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }
    private void OnDisable()
    {
        Event.DeregisterListener(this);
    }
}
