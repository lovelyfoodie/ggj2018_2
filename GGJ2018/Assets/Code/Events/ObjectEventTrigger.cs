//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObjectEventTrigger", menuName = "Event Triggers/Create Object Event")]
public class ObjectEventTrigger : ScriptableObject
{
    public bool showDebugInfo = false;
    protected List<ObjectEventTriggerListener> _listeners = new List<ObjectEventTriggerListener>();

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    public void RegisterListener(ObjectEventTriggerListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void DeregisterListener(ObjectEventTriggerListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    [ContextMenu("Raise")]
    public void Raise(object value)
    {
        for (int i = 0; i < _listeners.Count; i++)
        {
            if (showDebugInfo)
                Debug.LogFormat("Object Event Triggered on '{0}': {1} (Frame {2})", name, value.ToString(), Time.frameCount);

            _listeners[i].OnRaise.Invoke(value);
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("A Tofu Tail/Event Triggers/Create Object Event")]
#endif
    public static void CreateEventData()
    {
        ObjectEventTrigger asset = CreateInstance<ObjectEventTrigger>();
        UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Data/Events/NewObjectEventTrigger.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
    }
}

