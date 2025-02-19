using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DameSender
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = GetComponentInParent<BulletCtrl>();
        Debug.LogWarning(transform.name + " :LoadBulletCtrl", gameObject);
    }
    public override void Send(DameReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DameReceiver enemy = other.GetComponent<DameReceiver>();
        if (enemy != null)
        {
           Send(enemy);
        }
    }
}
