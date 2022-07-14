using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : BossStateBase
{
    [SerializeField] private float IdleStateDuration = 3;
    private float Timer;
    [SerializeField] private BossStateBase[] AttackStates;

    public override void OnStateEnter()
    {
        
        Timer = 0;
        
        Debug.Log("BossIdle");
    }

    public override void StateUpdate()
    {
        Timer += Time.deltaTime;

    }

    public override void OnStateExit()
    {

    }

    public override BossStateBase CheckTransition()
    {
        if (Timer >= IdleStateDuration)
        {
            return AttackStates [Random.Range(0, AttackStates.Length)];
        }
        return null;
    }
}
