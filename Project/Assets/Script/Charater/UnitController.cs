using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    //받아올 캐릭터 스크립트
    public Character character;

    //스킬,기본공격의 이펙트
    public GameObject Skill_Effect;
    public GameObject Attack_Effect;

    //스킬,기본공격의 이펙트위치
    public Vector3 Skill_Pos;
    public Vector3 Attack_Pos;

    //public
    public Sprite Passive;
    public Sprite Skill;

    // Start is called before the first frame update
    public void Start()
    {
        character.Initialsetting();
    }

    // Update is called once per frame
    void Update()
    {
        //character.Passive();
        //character.Attack();
    }
}
