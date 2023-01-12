using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Data
{
    //캐릭터이름
    public string name;
    public string info;
    //체력
    public float Max_Hp;
    public float Hp;

    //기본공격
    public float delay_time;
    public float damage;
    public float range;

    //스킬공격
    public string skill_name;
    public string skill_info;
    public float skill_delay;
    public float skill_damage;

    //패시브 스킬
    public string passive_name;
    public string passive_info;
}

public abstract class Character : MonoBehaviour
{
    #region Variable
    public enum State
    {
        Normal,
        Attack,
        Move,
    };
    
    float delay = 0.0f;
    float skill_delay = 0.0f;
    public Data data;
    State state = State.Normal;
    protected Animator ani;

    #endregion Variable

    public abstract void Initialsetting();
    public abstract void Skill();
    public abstract void Passive();

    public virtual void Attack()
    {
        if (state != State.Normal || data.Hp <= 0)
            return;
        else
        {
            delay += Time.deltaTime;
            skill_delay += Time.deltaTime;
        }

        if(skill_delay > data.skill_delay || delay > data.delay_time)
        {
            state = State.Attack;
            if (skill_delay > data.skill_delay)
            {
                Skill();
                skill_delay = 0.0f;
                delay = 0.0f;
            }
            else if (delay > data.delay_time)
            {
                Debug.Log("기본공격");
                delay = 0.0f;
            }
        }
        state = State.Normal;
    }

    public virtual void Move(Vector3 Direction)
    {

    }

    public void Damage(float damage)
    {
        data.Hp -= damage;
    } 

    public void Heal(float heal)
    {
        data.Hp += heal;
    }
}
