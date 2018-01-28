//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

public class EventServices : MonoBehaviour
{
    public ScriptableObject[] services;

    private static Dictionary<string, ScriptableObject> _services = new Dictionary<string, ScriptableObject>();

    //--------------------------------------------------------

    private void Awake()
    {
        foreach (var service in services)
        {
            _services[service.name] = service;
        }
    }

    //--------------------------------------------------------

    public static void Provide(ScriptableObject eventTrigger)
    {
        _services[eventTrigger.name] = eventTrigger;
    }
    public static TService Locate<TService>(string eventName) where TService : ScriptableObject
    {
        return (TService)_services[eventName];
    }
}