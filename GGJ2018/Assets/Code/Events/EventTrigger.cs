//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEventTrigger", menuName = "Event Triggers/Create Event")]
public class EventTrigger : ScriptableObject
{
    public bool showDebugInfo = false;
    protected List<EventTriggerListener> _listeners = new List<EventTriggerListener>();

    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        
    }

    public void RegisterListener(EventTriggerListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void DeregisterListener(EventTriggerListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    [ContextMenu("Raise")]
    public void Raise()
    {
        for (int i = 0; i < _listeners.Count; i++)
        {
            if (showDebugInfo)
                Debug.LogFormat("'{0}' Event {3} Triggered on '{2}' (Frame {1})", name, Time.frameCount, _listeners[i].gameObject.name, i);
            _listeners[i].OnRaise.Invoke();
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("A Tofu Tail/Event Triggers/Create Event")]
#endif
    public static void CreateEventData()
    {
        EventTrigger asset = CreateInstance<EventTrigger>();
        UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Data/Events/NewEventTrigger.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
    }
}
