using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapCamera : MonoBehaviour
{
    Transform Pos;
    Vector2 ClickPos,EndPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Pos = transform;
        //transform.position = GameObject.Find("Player").transform.transform.position + Pos.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ClickPos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            EndPos = Input.mousePosition;

            Vector3 Move = EndPos - ClickPos;
            transform.position -= new Vector3(Move.x, 0.0f, Move.y) * Time.deltaTime * speed;
        }
    }
}
