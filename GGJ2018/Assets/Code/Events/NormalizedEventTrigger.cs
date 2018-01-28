//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using UnityEngine;

[CreateAssetMenu(fileName = "NewNormalizedEventTrigger", menuName = "Event Triggers/Create Normalized Event")]
public class NormalizedEventTrigger : FloatEventTrigger
{
    [ContextMenu("Raise")]
    public new void Raise(float value)
    {
        for (int i = 0; i < _listeners.Count; i++)
        {
            value = Mathf.Clamp01(value);

            if (showDebugInfo)
                Debug.LogFormat("Normalized Event Triggered on '{0}': {1} (Frame {2})", name, value, Time.frameCount);

            _listeners[i].OnRaise.Invoke(value);
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("A Tofu Tail/Event Triggers/Create Normalized Event")]
#endif
    public new static void CreateEventData()
    {
        NormalizedEventTrigger asset = CreateInstance<NormalizedEventTrigger>();
        UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/Data/Events/NewNormalizedEventTrigger.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.EditorUtility.FocusProjectWindow();
        UnityEditor.Selection.activeObject = asset;
    }
}
