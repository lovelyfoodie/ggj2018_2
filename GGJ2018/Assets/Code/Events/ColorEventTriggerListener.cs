//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using UnityEngine;

public class ColorEventTriggerListener : MonoBehaviour
{
    public ColorEventTrigger Event;
    public ColorUnityEvent OnRaise;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }
    private void OnDisable()
    {
        Event.DeregisterListener(this);
    }
}
