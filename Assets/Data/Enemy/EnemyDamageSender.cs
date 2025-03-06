using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DameSender
{
    [Header("Enemy Attack")]
    [SerializeField] protected Collider2D collider2;
    [SerializeField] protected Rigidbody2D rid2;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (collider2 != null) return;
        collider2 = GetComponent<Collider2D>();
    }

    protected virtual void LoadRigidbody()
    {
        if (rid2 != null) return;
        rid2 = transform.parent.GetComponent<Rigidbody2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2)
    {
        PlayerDamageReceiver playerDamageReceiver = collider2.GetComponent<PlayerDamageReceiver>();
        if (playerDamageReceiver == null) return;
        Send(playerDamageReceiver);
    }
}
