using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVulnerable : BossStateBase
{

    public BossStateBase StateAfterHit;
    public BossStateBase StateAfterDeath;
    private BossStateBase SelectedNextState = null;
    public BossStateBase StaticState;

    public float HarmlessDuration = 1;
    private float lastHitTime = int.MinValue;

    private float Timer;
    private Collider2D coll;

    public float TiredDuration = 3;

    private void Start()
    {
        coll=GetComponent<Collider2D>();
    }

    public override BossStateBase CheckTransition()
    {
        return SelectedNextState;
    }

    public override void OnStateEnter()
    {
        Timer = 0;
        SelectedNextState = null;
    }

    public override void StateUpdate()
    {
        Timer += Time.deltaTime;
        if (Timer >= TiredDuration && SelectedNextState == null)
        {
            SelectedNextState = StaticState;
            controller.anim.SetBool("Vulnerable", false);
        }
    }

    public override void OnStateExit()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (controller.currentState == this && other.bounds.min.y >= coll.bounds.max.y - 0.05f)
            {
                TakeDamage(1);
                lastHitTime = Time.time;
            }
            else if(Time.time - lastHitTime>=HarmlessDuration)
            {
                other.gameObject.GetComponent<Player>().TakeDamage(1);
            }
            Debug.Log(other.gameObject.name + " " + Time.time);
        }
    }

    public void TakeDamage(int damage)
    {
        controller.anim.SetBool("Vulnerable", false);
        controller.health -= damage;
        if (controller.health <= 0)
        {
            SelectedNextState = StateAfterDeath;
            controller.anim.SetTrigger("Death");
        }
        else
        {
            SelectedNextState = StateAfterHit;
            controller.anim.SetTrigger("HitByPlayer");
        }
    }
}
