using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : Character
{
    public override void Initialsetting()
    {
        data.name = "바이킹";
        data.info = "바이킹입니다";

        data.Max_Hp = 50.0f;
        data.Hp = data.Max_Hp;

        data.delay_time = 3.0f;
        data.damage = 3.0f;
        data.range = 1.0f;

        data.skill_name = "강타";
        data.skill_info = "적에게 큰 피해를 줍니다.";
        data.skill_delay = 10.0f;
        data.skill_damage = 20.0f;

        data.passive_name = "광전사";
        data.passive_info = "적에게 피해를 줄 때 마다 공격속도가 증가합니다.";

        ani = GetComponent<Animator>();
    }

    public override void Skill()
    {
        Debug.Log("스킬사용");
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Move(Vector3 Direction)
    {
        base.Move(Direction);
    }

    public override void Passive()
    {
        Debug.Log("CC저항");
    }
}
