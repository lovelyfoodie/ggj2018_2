//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventTrigger))]
public class EventTriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var trigger = (EventTrigger)target;

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField("Scriptable Object Event", GUILayout.Width(EditorGUIUtility.labelWidth - 4));
            EditorGUILayout.SelectableLabel(target.GetType().Name, EditorStyles.textField, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        }
        EditorGUILayout.EndHorizontal();
        

        GUILayout.Space(10);
        trigger.showDebugInfo = GUILayout.Toggle(trigger.showDebugInfo, " Show Debug Info");
        GUILayout.Space(10);


        GUILayout.BeginVertical("Event Control", "window", GUILayout.Height(50f));
        EditorGUI.indentLevel += 1;
        GUILayout.Space(10);
        if (GUILayout.Button("Raise Event"))
        {
            trigger.Raise();
        }
        GUILayout.Space(10);
        EditorGUI.indentLevel -= 1;
        GUILayout.EndVertical();
    }
}
