using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubGumActivator : MonoBehaviour
{
    private BubEnemy BubbleGum_Monster;

    private void Awake()
    {
        BubbleGum_Monster = GetComponentInParent<BubEnemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BubbleGum_Monster.SetShooting(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BubbleGum_Monster.SetShooting(false);
        }
    }
}
