//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColorEventTrigger", menuName = "Event Triggers/Create Color Event")]
public class ColorEventTrigger : ScriptableObject
{
    public bool showDebugInfo = false;
    protected List<ColorEventTriggerListener> _listeners = new List<ColorEventTriggerListener>();

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    public void RegisterListener(ColorEventTriggerListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void DeregisterListener(ColorEventTriggerListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    [ContextMenu("Raise")]
    public void Raise(Color value)
    {
        for (int i = 0; i < _listeners.Count; i++)
        {
            if (showDebugInfo)
                Debug.LogFormat("Color Event Triggered on '{0}': {1} (Frame {2})", name, value.ToString(), Time.frameCount);

            _listeners[i].OnRaise.Invoke(value);
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("A Tofu Tail/Event Triggers/Create Color Event")]
    public static void CreateEventData()
    {
        ColorEventTrigger asset = CreateInstance<ColorEventTrigger>();
        UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Data/Events/NewColorEventTrigger.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
    }
#endif
}

