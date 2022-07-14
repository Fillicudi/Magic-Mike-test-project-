using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAfterHit : BossStateBase
{
    public BossStateBase StateToGoTo;

    public float Timer = 0;

    public float AfterHitDuration = 3;

    public override BossStateBase CheckTransition()
    {
        if (Timer >= AfterHitDuration)
        {
            if (controller.health == 0)
            {
                controller.OnBossDefeated();
                return null;
            }
            else
            {
                return StateToGoTo;
            }
            
        }
        return null;
    }

    public override void OnStateEnter()
    {
        Timer = 0;
    }

    public override void OnStateExit()
    {
        
    }

    public override void StateUpdate()
    {
        Timer += Time.deltaTime;
    }

    
}
