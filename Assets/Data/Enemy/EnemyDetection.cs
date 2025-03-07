using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : EnemyAbstract
{
    [Header("Enemy Detection")]
    [SerializeField] protected CircleCollider2D circleCollider2;
    [SerializeField] public bool Trigger = false;
   
  

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider();
    }

    protected virtual void LoadCircleCollider()
    {
        if (this.circleCollider2 != null) return;
        circleCollider2 = GetComponent<CircleCollider2D>();
    }

 
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PlayerDetected playerDetected = other.GetComponent<PlayerDetected>();
        if (playerDetected == null) return;
        this.Trigger = true;
    }

}
