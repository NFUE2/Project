using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : Character
{
    public override void Initialsetting()
    {
        Debug.Log("세팅");
        data.delaytime = 1.5f;
        data.damage = 3;
        data.skilldelay = 10.0f;
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Move(Vector3 Direction)
    {
        base.Move(Direction);
    }
}
