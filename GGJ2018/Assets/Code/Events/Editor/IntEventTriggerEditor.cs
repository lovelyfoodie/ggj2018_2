//------------------------------------------------------------------------------
// Copyright © 2017 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IntEventTrigger))]
public class IntEventTriggerEditor : Editor
{
    private int _value = 0;
    public override void OnInspectorGUI()
    {
        var trigger = (IntEventTrigger)target;

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
        _value = EditorGUILayout.IntField("Parameter", _value);
        GUILayout.Space(5);
        if (GUILayout.Button("Raise Event"))
        {
            trigger.Raise(_value);
        }
        GUILayout.Space(10);
        EditorGUI.indentLevel -= 1;
        GUILayout.EndVertical();
    }
}

