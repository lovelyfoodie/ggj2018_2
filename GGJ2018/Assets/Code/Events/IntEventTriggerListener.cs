//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using UnityEngine;

public class IntEventTriggerListener : MonoBehaviour
{
    public IntEventTrigger Event;
    public IntUnityEvent OnRaise;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }
    private void OnDisable()
    {
        Event.DeregisterListener(this);
    }
}
