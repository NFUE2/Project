using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node(Vector3 Pos1, Vector3 Pos2) { PrevNode = Pos1; CurNode = Pos2; }
    public Vector3 PrevNode, CurNode;
}


public class WorldMapPlayer : MonoBehaviour
{
    #region Variable
    public List<Vector3> Route;

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
        //Route.Clear();
        //Vector3 Cur_Pos = transform.position - new Vector3(0f, -1f, 0f);

        //List<Node> OpenNode = new List<Node>();
        //List<Vector3> CloseNode = new List<Vector3>();

        //Node Cur_Node = new Node(Cur_Pos, Cur_Pos);
        
        //OpenNode.Add(Cur_Node);

        //while(OpenNode.Count > 0)
        //{
        //    OpenNode.Remove(Cur_Node);
        //    CloseNode.Add(Cur_Pos);

        //    if(Cur_Pos == Pos)
        //    {
        //        Cur_Node.
        //        break;
        //    }

        //    for (int i = 0; i < 6; i++)
        //    {
        //        if(GameManager.GetInstance().NodeCheck(Cur_Pos + Nodelist[i]) && !CloseNode.Contains(Cur_Pos + Nodelist[i]))
        //        {
        //            Cur_Node = new Node(Cur_Pos, Cur_Pos + Nodelist[i]);
        //        }
        //    }
        //}
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < Route.Count - 1; i++)
           Gizmos.DrawLine(Route[i], Route[i + 1]);
    }
}