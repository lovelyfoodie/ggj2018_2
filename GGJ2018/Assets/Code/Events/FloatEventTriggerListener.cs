//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using UnityEngine;

public class FloatEventTriggerListener : MonoBehaviour
{
    public FloatEventTrigger Event;
    public FloatUnityEvent OnRaise;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }
    private void OnDisable()
    {
        Event.DeregisterListener(this);
    }
}
