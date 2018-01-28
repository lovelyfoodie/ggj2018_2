//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFloatEventTrigger", menuName = "Event Triggers/Create Float Event")]
public class FloatEventTrigger : ScriptableObject
{
    public bool showDebugInfo = false;
    protected List<FloatEventTriggerListener> _listeners = new List<FloatEventTriggerListener>();

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    public void RegisterListener(FloatEventTriggerListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void DeregisterListener(FloatEventTriggerListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    [ContextMenu("Raise")]
    public void Raise(float value)
    {
        for (int i = 0; i < _listeners.Count; i++)
        {
            if (showDebugInfo)
                Debug.LogFormat("Float Event Triggered on '{0}': {1} (Frame {2})", name, value, Time.frameCount);

            _listeners[i].OnRaise.Invoke(value);
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("A Tofu Tail/Event Triggers/Create Float Event")]
#endif
    public static void CreateEventData()
    {
        FloatEventTrigger asset = CreateInstance<FloatEventTrigger>();
        UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Data/Events/NewFloatEventTrigger.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
    }
}
