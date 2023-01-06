using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

public class MapEditor : EditorWindow
{
    #region Variable
    List<Vector3> OpenNode;
    List<Vector3> CloseNode;

    Object[] Tilelist;
    int choice;
    GameObject Base,SelectTile;

    #endregion Variable
    [MenuItem("Editor/MapEditor")]
    static void ShowWindow()
    {
        GetWindow(typeof(MapEditor)).Show();
    }

    private static MapEditor Instance;

    public static MapEditor GetInstance()
    {
        if (Instance == null)
            Instance = new MapEditor();

        return Instance;
    }

    private void Awake()
    {
        OpenNode = new List<Vector3>();
        CloseNode = new List<Vector3>();
        
        Base = Resources.Load<GameObject>("EditorResource/Node");
        if (GameObject.Find("OpenNode") == null)
            new GameObject("OpenNode");
        else
        {
            for (int i = 0; i < GameObject.Find("OpenNode").transform.childCount; i++)
                OpenNode.Add(GameObject.Find("OpenNode").transform.GetChild(i).position);
        }

        if (GameObject.Find("CloseNode") == null)
            new GameObject("CloseNode");
        else
        {
            for (int i = 0; i < GameObject.Find("CloseNode").transform.childCount; i++)
                CloseNode.Add(GameObject.Find("CloseNode").transform.GetChild(i).position);
        }

        if (GameObject.Find("OpenNode").transform.childCount == 0)
        {
            GameObject Obj = Instantiate(Base);
            Obj.transform.SetParent(GameObject.Find("OpenNode").transform);
            Obj.transform.position = Vector3.zero;

            OpenNode.Add(Obj.transform.position);
        }
        Tilelist = Resources.LoadAll<Object>("EditorResource/Ground");
    }

    private void OnGUI()
    {
        if (Tilelist.Length > 0)
        {
            Texture[] Thumnail = new Texture[Tilelist.Length];

            for (int i = 0; i < Tilelist.Length; i++)
                Thumnail[i] = AssetPreview.GetAssetPreview(Tilelist[i]);

            choice = GUILayout.SelectionGrid(choice,Thumnail,4,GUILayout.MaxHeight(100f),GUILayout.MaxWidth(500f));
            SelectTile = (GameObject)Tilelist[choice];
        }
    }

    public void Create(Vector3 Pos)
    {
        GameObject Obj = Instantiate((GameObject)Tilelist[choice]);

        Obj.transform.SetParent(GameObject.Find("CloseNode").transform);
        Obj.transform.rotation = Quaternion.AngleAxis(30.0f, Vector3.up);
        Obj.transform.position = Pos;

        OpenNode.Remove(Pos);
        CloseNode.Add(Pos);
        Search(Pos);
    }

    public void Search(Vector3 Pos)
    {
        for (int i = 0; i < 6; i++)
        {
            float angle = ((i * 60f) + 30f) * Mathf.Deg2Rad;
            Vector3 Preview = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * (2.5f * 2) + Pos;

            if(Physics.OverlapSphere(Preview,0.5f).Length == 0)
            {
                OpenNode.Add(Preview);

                GameObject Obj = Instantiate(Base);
                Obj.transform.SetParent(GameObject.Find("OpenNode").transform);
                Obj.name = "Point";
                Obj.transform.position = Preview;
            }
            //if (!OpenNode.Contains(Preview) && !CloseNode.Contains(Preview))
            //{
            //    OpenNode.Add(Preview);

            //    GameObject Obj = Instantiate(Base);
            //    Obj.transform.SetParent(GameObject.Find("OpenNode").transform);
            //    Obj.name = "Point";
            //    Obj.transform.position = Preview;
            //}
        }
    }
}

