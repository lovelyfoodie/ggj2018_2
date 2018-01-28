//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIntEventTrigger", menuName = "Event Triggers/Create Int Event")]
public class IntEventTrigger : ScriptableObject
{
    public bool showDebugInfo = false;
    protected List<IntEventTriggerListener> _listeners = new List<IntEventTriggerListener>();

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    public void RegisterListener(IntEventTriggerListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void DeregisterListener(IntEventTriggerListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    [ContextMenu("Raise")]
    public void Raise(int value)
    {
        for (int i = 0; i < _listeners.Count; i++)
        {
            if (showDebugInfo)
                Debug.LogFormat("Int Event Triggered on '{0}': {1} (Frame {2})", name, value, Time.frameCount);

            _listeners[i].OnRaise.Invoke(value);
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("A Tofu Tail/Event Triggers/Create Int Event")]
#endif
    public static void CreateEventData()
    {
        IntEventTrigger asset = CreateInstance<IntEventTrigger>();
        UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Data/Events/NewIntEventTrigger.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
    }
}

