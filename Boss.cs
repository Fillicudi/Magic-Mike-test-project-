using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour  
{
    public int AttacksCounter = 0;
    public int NumAttacksBeforeTired = 3;
    public float startTimeBtwShots;
    public Projectile projectile;
    public Player player;
    public int health = 3;
    private BoxCollider2D coll;

    public Animator anim;

    public BossStateBase currentState;

    public BossStateBase defaultState;

    private bool BossComplete = false;

    public void OnBossDefeated()
    {
        BossComplete = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        currentState = defaultState;

        currentState.OnStateEnter();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossComplete == true)
        {
            return;
        }
        currentState.StateUpdate();
        BossStateBase NextState = currentState.CheckTransition(); //usare lo stesso per l'anim di morte
        if (NextState != null)
        {
            currentState.OnStateExit();
            currentState = NextState;
            currentState.OnStateEnter();
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.bounds.min.y >= coll.bounds.max.y - 0.05f)
            {
                TakeDamage(1);
            }
            else
            {
                other.gameObject.GetComponent<Player>().TakeDamage(1);
            }
        }
    }
    */
    
}
