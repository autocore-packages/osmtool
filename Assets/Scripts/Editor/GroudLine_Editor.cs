using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GroundLine))]
public class GroudLine_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("SetLine"))
        {
            GroundLine groundLine = target as GroundLine;
            groundLine.SetLines();
        }
    }
}
