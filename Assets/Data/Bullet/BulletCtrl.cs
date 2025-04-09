using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : TrisMonoBehaviour
{
    [Header("Bullet Ctrl")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected BulletFly bulletFly ;
    public BulletFly BulletFly =>bulletFly ;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;
    [SerializeField] protected WeaponProfileSO weaponProfile;
    public WeaponProfileSO WeaponProfile => weaponProfile;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletFly();
        this.LoadModel();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadBulletFly()
    {
        if(bulletFly!=null)return;
        bulletFly = GetComponentInChildren<BulletFly>();
    }
    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = GetComponentInChildren<BulletDespawn>();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
    }
}
