using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Player player;
    protected BoxCollider2D coll;
    [SerializeField] protected int health; 

    /*
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            other.gameObject.GetComponent<Player>().TakeDamage(1);
        }
    }
    */
    public virtual void TakeDamage(int damage)
    {
        health -= damage; 
        if (health <=0)
        {
            Destroy(this.gameObject); 
        }
    }
    
}
