using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPlayer : MonoBehaviour
{
    #region Variable
    public List<Vector3> Route;

    List<Vector3> OpenNode = new List<Vector3>();
    List<Vector3> CloseNode = new List<Vector3>();

    Vector3[] Nodelist =
    {
        new Vector3(0.0f, 0.0f, 5.0f),
        new Vector3(0.0f, 0.0f, -5.0f),
        new Vector3(4.3f, 0.0f, 2.5f),
        new Vector3(-4.3f, 0.0f, 2.5f),
        new Vector3(4.3f, 0.0f, -2.5f),
        new Vector3(-4.3f, 0.0f, -2.5f)
    };
    #endregion Variable

    private static WorldMapPlayer Instance;
    public static WorldMapPlayer GetInstance()
    {
        if (Instance == null)
            Instance = new WorldMapPlayer();
        return Instance;
    }

    private void Start()
    {
        Route = new List<Vector3>();
    }

    private void Update()
    {
        
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit Hit) && Hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Search(Hit.collider.gameObject.transform.position);
            }
        }
    }

    public void Search(Vector3 Pos)
    {
        Route.Clear();
        List<Vector3> OpenNode = new List<Vector3>();
        List<Vector3> CloseNode = new List<Vector3>();
        Dictionary<Vector3, Vector3> Node = new Dictionary<Vector3, Vector3>();

        OpenNode.Add(transform.position);

        while (OpenNode.Count > 0)
        {
            Vector3 CurPos = OpenNode[0];

            OpenNode.Remove(CurPos);
            CloseNode.Add(CurPos);

            for (int i = 0; i < 6; i++)
            {
                if (GameManager.GetInstance.NodeCheck(CurPos + Nodelist[i]) && !CloseNode.Contains(CurPos + Nodelist[i]) && !OpenNode.Contains(CurPos + Nodelist[i]))
                {
                    Node.Add(CurPos + Nodelist[i], CurPos);
                    OpenNode.Add(CurPos + Nodelist[i]);
                }
            }

            if (OpenNode.Contains(Pos))
            {
                CurPos = Pos;
                while (CurPos != transform.position)
                {
                    Route.Add(CurPos);
                    CurPos = Node[CurPos];
                }
                Route.Add(transform.position);
                Route.Reverse();
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < Route.Count - 1; i++)
            Gizmos.DrawLine(Route[i] + new Vector3(0, 1.0f, 0), Route[i + 1] + new Vector3(0, 1.0f, 0));
    }
}