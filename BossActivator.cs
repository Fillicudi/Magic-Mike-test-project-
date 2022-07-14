using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{  
    private NotPresent Calzino;

    private void Awake()
    {
        Calzino = GetComponentInParent<NotPresent>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Calzino.GetController().anim.SetTrigger("Appear");
            Calzino.playerInTrigger = true; 
        }
    }
  
}
