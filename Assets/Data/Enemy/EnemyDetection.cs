using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : EnemyAbstract
{
    [Header("Enemy Detection")]
    [SerializeField] protected CircleCollider2D circleCollider2;
    [SerializeField] protected Transform player;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider();
        this.LoadPlayer();
    }

    protected virtual void LoadCircleCollider()
    {
        if (this.circleCollider2 != null) return;
        circleCollider2 = GetComponent<CircleCollider2D>();
    }
    protected virtual void LoadPlayer()
    {
        if(this.player != null) return;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.transform;
    }
  

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
       PlayerDetected playerDetected = other.GetComponent<PlayerDetected>();
        if (playerDetected == null) return;
       enemyCtrl.EnemyMovement.gameObject.SetActive(true);
    }

}
