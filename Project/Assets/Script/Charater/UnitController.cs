using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        character.Initialsetting();
    }

    // Update is called once per frame
    void Update()
    {
        character.Attack();
    }
}
