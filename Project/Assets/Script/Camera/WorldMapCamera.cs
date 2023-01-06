using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapCamera : MonoBehaviour
{
    public Vector3 Pos;
    Vector2 ClickPos,MovePos;
    public float speed;
    bool ClickChk;

    // Start is called before the first frame update
    void Start()
    {
        Pos = transform.position;
        ClickChk = false;
    }

    void Update()
    {

        //if (Input.GetMouseButtonUp(0))
        //    ClickChk = true;

        //if(ClickChk)
        //{
        //    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    //if (Physics.Raycast(ray, out RaycastHit Hit))
        //    //    transform.position = Vector3.Lerp(transform.position, transform.position + Hit.collider.gameObject.transform.position, Time.deltaTime);

        //    //if (Vector3.Distance(transform.position, transform.position + Hit.collider.gameObject.transform.position) < 0.1f)
        //    //    ClickChk = false;
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    //ClickChk = false;
        //    //MovePos = Input.mousePosition;

        //    //Vector3 Move = MovePos - ClickPos;
        //    //transform.position -= new Vector3(Move.x, 0.0f, Move.y) * Time.deltaTime * speed;
        //}
    }
}
