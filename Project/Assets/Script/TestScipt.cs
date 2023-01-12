using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScipt : MonoBehaviour
{
    public GameObject Obj;


    public void OnClick()
    {
        Obj.GetComponent<Character>().Damage(5.0f);
    }
}
