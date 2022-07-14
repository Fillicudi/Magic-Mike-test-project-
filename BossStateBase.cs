using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boss))] //avverte Unity e dice: Questa componente per essere usata richiede la componente boss, un po' come joint e rigidbody.

public abstract class BossStateBase : MonoBehaviour
{

    protected Boss controller;
    public Boss GetController() 
    {
        return controller; 
    }
    public abstract void OnStateEnter();

    public abstract void StateUpdate();

    public abstract void OnStateExit();

    public abstract BossStateBase CheckTransition();
    // quando fai classe abstract impedisci a Unity e codice di usare questa classe perché troppo generica.

    void Awake()
    {
        controller = GetComponent<Boss>();
    }


}
