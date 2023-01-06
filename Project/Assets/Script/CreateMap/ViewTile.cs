using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ViewTile : MonoBehaviour
{
    #region Variable
    Vector3[] Pos = new Vector3[6];
    //public Vector3[] Tile_vertices = new Vector3[7];
    //int[] Tile_triangles = new int[18];

    public float size = 2.88f;

    #endregion Variable
    //private void Start()
    //{
    //    //for (int i = 0; i < 6; i++)
    //    //{
    //    //    Tile_triangles[i * 3] = 0;
    //    //    Tile_triangles[i * 3 + 1] = i + 1;
    //    //    Tile_triangles[i * 3 + 2] = i + 2;
    //    //}
    //    //Tile_triangles[17] = 1;

    //    //Mesh mesh = new Mesh();
    //    //mesh.vertices = Tile_vertices;
    //    //mesh.triangles = Tile_triangles;
    //    //GetComponent<MeshFilter>().mesh = mesh;
    //}

    private void OnDrawGizmos()
    {
        for (int i = 0; i < 6; i++)
        {
            float n = ((60 * i)) * Mathf.Deg2Rad;
            Pos[i] = new Vector3(Mathf.Sin(n), 0f, Mathf.Cos(n)) * size + transform.position;
        }
        for (int i = 0; i < 5; i++)
            Gizmos.DrawLine(Pos[i], Pos[i + 1]);
        Gizmos.DrawLine(Pos[5], Pos[0]);

        //Tile_vertices[0] = transform.position;
        //for (int i = 0; i < 6; i++)
        //    Tile_vertices[i + 1] = Pos[i];
    }
}

[CustomEditor(typeof(ViewTile))]
public class CreateButton : Editor
{
    private void OnSceneGUI()
    {
        ViewTile Button = (ViewTile)target;

        if (Handles.Button(Button.transform.position, Quaternion.AngleAxis(90, Button.transform.right), 1.7f, 2.5f, Handles.RectangleHandleCap))
        {
            MapEditor.GetInstance().Create(Button.transform.position);
            Destroy(Button.gameObject);
        } 
    }
}