using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDameReceiver : DameReceiver
{
    [Header("Shootable Object DameReceiver")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl=>shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if(shootableObjectCtrl != null)return;
        shootableObjectCtrl = GetComponentInParent<ShootableObjectCtrl>();
    }
    protected override void OnDead()
    {
        shootableObjectCtrl.Spawner.Despawn(transform.parent);
    }

    public virtual void DropItemOnDead()
    {
        Vector3 posDrop = transform.position;
        Quaternion rotDrop =transform.rotation;
        ItemDropSpawner.Instance.Drop(shootableObjectCtrl.ShootableObjsProfileSO.dropList,posDrop,rotDrop);

    }
    public override void SetHP()
    {
        this.maxHp = this.shootableObjectCtrl.ShootableObjsProfileSO.hpMax;
        base.SetHP();
    }
}
