//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBoolEventTrigger", menuName = "Event Triggers/Create Bool Event")]
public class BoolEventTrigger : ScriptableObject
{
    public bool showDebugInfo = false;
    protected List<BoolEventTriggerListener> _listeners = new List<BoolEventTriggerListener>();

    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    public void RegisterListener(BoolEventTriggerListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }
    public void DeregisterListener(BoolEventTriggerListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    [ContextMenu("Raise")]
    public void Raise(bool value)
    {
        for (int i = 0; i < _listeners.Count; i++)
        {
            if (showDebugInfo)
                Debug.LogFormat("'{0}' Bool Event {4} Triggered on '{3}': {1} (Frame {2})", name, value, Time.frameCount, _listeners[i].gameObject.name, i);

            _listeners[i].OnRaise.Invoke(value);
        }
    }
    public void RaiseInverse(bool value)
    {
        Raise(!value);
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("A Tofu Tail/Event Triggers/Create Bool Event")]
#endif
    public static void CreateEventData()
    {
        BoolEventTrigger asset = CreateInstance<BoolEventTrigger>();
        UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Data/Events/NewBoolEventTrigger.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
    }
}
