using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCamera : MonoBehaviour
{
    bool Pick_up;
    GameObject Pick_Target,Tile;

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        Cursor.lockState = CursorLockMode.Confined;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        foreach (RaycastHit Hit in Physics.RaycastAll(ray, 50.0f))
        {
            if (Hit.collider.gameObject.layer == 9)
                Tile = Hit.collider.gameObject;

            if (Input.GetMouseButtonDown(0))
            {
                if (Hit.collider.tag == "Player")
                {
                    Pick_up = true;
                    Pick_Target = Hit.collider.gameObject;
                }
            }

            if (Pick_up)
            {
                if (Input.GetMouseButton(0))
                    Pick_Target.transform.position = new Vector3(Hit.point.x, 0f, Hit.point.z);

                if (Input.GetMouseButtonUp(0))
                {
                    if (Hit.collider.gameObject.layer == 9)
                    {
                        StageManager.GetInstance.SetUnit(Pick_Target, Tile.transform.position);
                        Pick_Target.transform.position = Tile.transform.position;
                        Pick_up = false;
                    }
                    else
                        Pick_Target.transform.position = StageManager.GetInstance.UnitPos(Pick_Target);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit))
        {
            Gizmos.DrawSphere(Hit.point,0.5f);
        }
    }
}
