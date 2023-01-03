using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapEditor : EditorWindow
{
    [MenuItem("Editor/MapEditor")]
    static void ShowWindow()
    {
        GetWindow(typeof(MapEditor)).Show();
    }

    List<GameObject> OpenNode;
    List<GameObject> CloseNode;




}
