using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanaPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    public float startWaitTime;
    public int health = 1;
    public bool originalGraphicsLooksRight;
    private SpriteRenderer spriteRenderer;
    private float waitTime;
    private BoxCollider2D coll;
    private int randomSpot;
    [SerializeField] private Player player;
    
    
   


    // bool shouldFaceRight = destinazione.pos.x - gameObject.pos.x > 0




    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        originalGraphicsLooksRight = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>(); 
    }
    private void Update()
    {

         
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime); 
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) <0.2f)
            {
            if(waitTime <=0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                bool shouldFaceRight = moveSpots[randomSpot].position.x > transform.position.x ;
                if (shouldFaceRight == false)
                {
                    this.spriteRenderer.flipX = originalGraphicsLooksRight; 
                } else
                {
                    this.spriteRenderer.flipX = (originalGraphicsLooksRight == false); 
                }


                waitTime = startWaitTime; 
            }
            else
            {
                waitTime -= Time.deltaTime; 
            }

        }

    }
  

        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.bounds.min.y >= coll.bounds.max.y - 0.05f)
            {
                TakeDamage(1); 
            } else
            {
                other.gameObject.GetComponent<Player>().TakeDamage(1); 
            }
        }
    }
        
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
