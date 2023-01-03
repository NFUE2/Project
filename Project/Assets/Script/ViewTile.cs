using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ViewTile : MonoBehaviour
{
    #region Variable
    Vector3[] Pos = new Vector3[6];
    public Vector3[] Tile_vertices = new Vector3[7];
    public int[] Tile_triangles = new int[15];

    public float size = 1.0f;
    MeshFilter MF;
    Mesh mesh;
    #endregion Variable

    private void OnDrawGizmos()
    {
        for (int i = 0; i < 6; i++)
        {
            float n = (60 * i) * Mathf.Deg2Rad;

            //육각 타일 길이만큼 곱해주기
            Pos[i] = new Vector3(Mathf.Sin(n), 0f, Mathf.Cos(n)) * size;
        }
        for (int i = 0; i < 5; i++)
            Gizmos.DrawLine(Pos[i], Pos[i + 1]);

        Gizmos.DrawLine(Pos[5], Pos[0]);

        Tile_vertices[0] = transform.position;

        for (int i = 0; i < 6; i++)
            Tile_vertices[i + 1] = Pos[i];

        for (int i = 0; i < 5; i++)
        {
            Tile_triangles[i * 3] = 0;
            Tile_triangles[i * 3 + 1] = i + 1;
            Tile_triangles[i * 3 + 2] = i + 2;
        }
        //mesh.vertices = Tile_vertices;
        //mesh.triangles = Tile_triangles;
        //MF.mesh = mesh;
    }
}

[CustomEditor(typeof(ViewTile))]
public class CreateButton : Editor
{
    private void OnSceneGUI()
    {
        ViewTile Button = (ViewTile)target;

        if(Handles.Button(Button.transform.position, Quaternion.AngleAxis(90, Button.transform.right), 1.0f, 2.0f, Handles.RectangleHandleCap))
            Debug.Log("버튼작동");
    }
}