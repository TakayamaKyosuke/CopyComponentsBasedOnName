using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CopyComponentsBasedOnName))]
public class ModelManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {

        CopyComponentsBasedOnName copyComponentsBasedOnName = target as CopyComponentsBasedOnName;

        base.OnInspectorGUI();

        if (GUILayout.Button("Copy"))
        {
            copyComponentsBasedOnName.CopyComponents();

        }
    }
}

