using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform playerPos;
    private Vector2 target;
    

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //se volessi che il proiettile seguisse il giocatore, sostituire qua sopra target con player.position
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("Player"))
         {
         other.GetComponent<Player>().TakeDamage(1); 
             DestroyProjectile();
         }
     }

     void DestroyProjectile()
     {
         Destroy(gameObject);
     }

     public void Setup(Transform target )
     {
     this.target = target.position; 
     }
}

