using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotPresent : BossStateBase
{
    public BossStateBase StateToGoTo;
    public bool playerInTrigger; 

    public override BossStateBase CheckTransition()
    {
       if(playerInTrigger)
        {
            return StateToGoTo;
        } else
        {
            return null; 
        }
        
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void StateUpdate()
    {
        
    }

    
}
