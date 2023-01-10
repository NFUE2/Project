using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Data
{
    public float delaytime;
    public int damage;
    public float skilldelay;
}

public abstract class Character : MonoBehaviour
{
    #region Variable
    public enum State
    {
        Normal,
        Attack,
        Defense,
        Stun,
        Move,
    };

    float delay = 0.0f;
    public Data data;
    State state = State.Normal;

    #endregion Variable

    public abstract void Initialsetting();

    public virtual void Attack()
    {
        if (state == State.Stun)
            return;
        else
            delay += Time.deltaTime;

        if(delay > data.delaytime)
        {
            Debug.Log("공격");
            delay = 0.0f;
        }
    }
    
    public virtual void Move(Vector3 Direction)
    {

    }
}
