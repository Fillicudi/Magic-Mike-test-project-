using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestructibleCrate : MonoBehaviour
{
    //l'animazione parte subito, devo fare in modo che questa parta 
    //si distrugga il mesh collider, avvi l'animazione di distruzione e SOLO a fine animazione deve
    //distruggersi l'oggetto  
    
    public float timeBeforeAnim = 3;
    public float animDuration = 1;
    private AudioSource breaking;

    private Animator anim;
    private Collider2D coll;
    private bool isDestructing = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        breaking = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" )
        {
            // Controllo che il limite minimo sulle Y (la parte piu' bassa) di chi mi e' venuto addosso
            // Stia piu' in alto del limite massimo sulle Y (la parte piu' alta) di questa cassa (il collider e' coll)
            if ( collision.collider.bounds.min.y >= coll.bounds.max.y - 0.05f ) // - 0.05f e' un piccolo errore per facilitare la formula
            {
                StartCoroutine(ManageDestroy());
            }
            
        }
    }

    public void PlayDestruction()
    {
        if (isDestructing == true)
        {
            return; // Se si sta gia' distruggendo, accanna
        }
        isDestructing = true;

        anim.Play("Box_Destruction");
        BreakingBox();
        coll.enabled = false;
        Destroy(gameObject, animDuration);
        Debug.Log("Destruction!");
    }

    IEnumerator ManageDestroy()
    {
        yield return new WaitForSeconds(timeBeforeAnim);
        PlayDestruction();
    }
    private void BreakingBox()
    {
        breaking.Play();
    }
}
