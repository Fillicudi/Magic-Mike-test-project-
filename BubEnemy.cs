using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubEnemy : Enemy
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Projectile projectile;
    //public Player player;
    //private int health;

    private bool IsShooting;
   

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        health = 2; 
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Vector2.Distance(transform.position,player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) 
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        */

        if (IsShooting == false)
        {
            return;
        }

        if(timeBtwShots <= 0)
        {
            Projectile clone = Instantiate(projectile, transform.position, Quaternion.identity);
            clone.Setup(player.transform); 
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;  
        }

    }

    public void SetShooting(bool value)
    {
        IsShooting = value;
    }

}
