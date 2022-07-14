using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private AudioSource follower;
    private Collider2D coll;
    private SpriteRenderer spriteRender;

    private void Start()
    {
        follower = GetComponent<AudioSource>();
        coll = GetComponent<Collider2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("Player"))
        {
            PickItem();
            other.GetComponent<Player>().AddScore(1);
            //gameObject.SetActive(false);
            coll.enabled = false;
            spriteRender.enabled = false;
            Destroy(this.gameObject, 2);
            
        }
    }
    private void PickItem()
    {
        Debug.Log("Quello che ti pare, scritto");
        follower.Play();
    }
}
