using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    #region Variable

    List<Vector3> Tile;
    Dictionary<GameObject, Vector3> UnitCheck;

    #endregion Variable
    private static StageManager Instance = null;
    public static StageManager GetInstance { get { return Instance; } }

    void Start()
    {
        Instance = this;
        Tile = new List<Vector3>();
        UnitCheck = new Dictionary<GameObject, Vector3>();

        for (int i = 0; i < GameObject.Find("CloseNode").transform.childCount; i++)
            Tile.Add(GameObject.Find("CloseNode").transform.GetChild(i).transform.position);
    }

    public void SetUnit(GameObject Unit,Vector3 Pos)
    {
        if (UnitCheck.ContainsKey(Unit))
            UnitCheck.Remove(Unit);
        UnitCheck.Add(Unit,Pos);
    }

    public Vector3 UnitPos(GameObject Unit) { return UnitCheck[Unit]; }
}
