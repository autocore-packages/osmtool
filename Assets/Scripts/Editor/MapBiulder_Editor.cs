using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(MapBuilder))]
public class MapBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Build Map"))
        {
            MapBuilder mapBuilder = target as MapBuilder;
            mapBuilder.BuildMap();
        }
    }
}
