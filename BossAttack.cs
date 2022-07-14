using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] // <- serve a farlo comparire nell'inspector
public class BossAttackSingleBulletLine
{
    public Transform start;
    public Transform end;
}

public class BossAttack : BossStateBase 
{

    public string nomeAttaccoDiDebug = "Attacco1";

    [SerializeField] private float AttackAnimDuration = 1;
    private float Timer;
    [SerializeField] private BossStateBase StateToGoTo;
    [SerializeField] private BossStateBase TiredState;
    [SerializeField] private Projectile projectile;
    private object player;

    [SerializeField] private BossAttackSingleBulletLine[] bullets; // <- dati per gestire i proiettili

    //trigger da chiamare per i vari titi di attacco;

    public override void OnStateEnter()
    {
        //to do: esponete proiettili
        
        Timer = 0;
        Debug.Log("BossAttack: " + nomeAttaccoDiDebug);

        // facciamo nascere tuti i proiettili assieme
        for(int i = 0; i < bullets.Length; i++)
        {
            // Per ciascun proiettile lo faccio comparire nello start e lo faccio finire nell'end
            Projectile clone = Instantiate(projectile, bullets[i].start.position, Quaternion.identity);
            clone.Setup(bullets[i].end);
        }

        

        controller.anim.SetTrigger(nomeAttaccoDiDebug);

        controller.AttacksCounter++;

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
        if (Timer >= AttackAnimDuration)
        {
            if (controller.AttacksCounter >= controller.NumAttacksBeforeTired)
            {
                controller.AttacksCounter = 0;
                controller.anim.SetBool("Vulnerable", true);

                return TiredState;
            }
            else
            {
                controller.anim.SetTrigger("GoStatic");
                return StateToGoTo;
            }
        }
        return null;
    }

    
}
