using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Choice_Character : MonoBehaviour
{
    public GameObject Player;

    public List<GameObject> Unit;
    public List<GameObject> Choice_Slot;
    GameObject Choice_Unit;
    private void Start()
    {
        for (int i = 0; i < Unit.Count; i++)
        {
            Unit[i].GetComponent<UnitController>().Start();
            Choice_Slot[i].transform.GetChild(0).GetComponent<Text>().text
                = Unit[i].GetComponent<UnitController>().character.data.name;

            Texture2D Thumnail = AssetPreview.GetAssetPreview(Unit[i]);
            Choice_Slot[i].transform.GetChild(1).GetComponent<Image>().sprite
                = Sprite.Create(Thumnail, new Rect(0, 0, Thumnail.width, Thumnail.height), new Vector2(0.5f, 0.5f));

            Choice_Slot[i].transform.GetChild(2).GetComponent<Image>().sprite
                = Unit[i].GetComponent<UnitController>().Passive;

            Choice_Slot[i].transform.GetChild(3).GetComponent<Image>().sprite
                = Unit[i].GetComponent<UnitController>().Skill;

            Choice_Slot[i].transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text
                = Unit[i].GetComponent<UnitController>().character.data.info;
        }
    }

    public void Choice()
    {
        if (Choice_Unit != null)
        {
            GameManager.GetInstance.GetUnit = Choice_Unit;
            Player.SetActive(true);
            transform.root.gameObject.SetActive(false);
        }
    }
    public void Viking()
    {
        Choice_Unit = Unit[0];
    }
    public void Gunslinger()
    {
        Choice_Unit = Unit[1];
    }
    public void Magician()
    {
        Choice_Unit = Unit[2];
    }
}

