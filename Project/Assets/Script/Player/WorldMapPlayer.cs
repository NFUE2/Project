using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPlayer : MonoBehaviour
{
    public List<Vector3> Node;
    Vector3[] Nodelist =
    {
        new Vector3(0.0f, 0.0f, 5.0f),
        new Vector3(0.0f, 0.0f, -5.0f),
        new Vector3(4.3f, 0.0f, 2.5f),
        new Vector3(-4.3f, 0.0f, 2.5f),
        new Vector3(4.3f, 0.0f, -2.5f),
        new Vector3(-4.3f, 0.0f, -2.5f)
    };


    private static WorldMapPlayer Instance;
    public static WorldMapPlayer GetInstance()
    {
        if (Instance == null)
            Instance = new WorldMapPlayer();
        return Instance;
    }

    private void Start()
    {
        Node = new List<Vector3>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit Hit) && Hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                Search(Hit.collider.gameObject.transform.position);
        }
    }

    public void Search(Vector3 Pos)
    {
        Node.Clear();
        Vector3 Cur_Pos = transform.position /*- new Vector3(0f,-1f,0f)*/;
        Vector3 Next = Nodelist[0] + Cur_Pos;
        Node.Add(transform.position);

        //while (!Node.Contains(Pos))
        for (int j = 0; j < 2; j++)
        {
            for (int i = 1; i < 6; i++)
            {
                Vector3 CheckNode = Nodelist[i] + Cur_Pos;
                Next = Vector3.Distance(Next, Pos) > Vector3.Distance(CheckNode, Pos) ? CheckNode : Next;
            }
            Cur_Pos = Next;
            Node.Add(Next);
        }

        if (Node.Contains(Pos))
        {
            Debug.Log("완료");
        }
        Debug.Log(Pos);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < Node.Count - 1; i++)
        {
           Gizmos.DrawLine(Node[i],Node[i + 1]);
        }
    }
}
