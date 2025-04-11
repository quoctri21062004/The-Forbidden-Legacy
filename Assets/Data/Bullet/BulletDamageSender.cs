using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DameSender
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected AmmoProfileSO ammoProfileSO;
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

    protected virtual void SetupDameReceiver()
    {
        this.damage = bulletCtrl.WeaponProfile.ammoProfile.damageSender;
    }
    public override void Send(DameReceiver damageReceiver)
    {
        SetupDameReceiver();
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ShootableObjectDameReceiver enemy = other.GetComponent<ShootableObjectDameReceiver>();
        if (enemy != null)
        {
           Send(enemy);
        }
    }
}
