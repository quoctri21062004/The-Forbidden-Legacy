using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : TrisMonoBehaviour
{
    [Header("Shootable Object Ctrl")]
    [SerializeField] protected ShootableObjsProfileSO shootableObjsProfileSO;
    public ShootableObjsProfileSO ShootableObjsProfileSO =>shootableObjsProfileSO;

    [SerializeField] protected DameReceiver dameReceiver;
    public DameReceiver DameReceiver => dameReceiver;

    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadShootableObj();
        this.LoadDameReceiver();
        this.LoadDespawn();
    }
    protected virtual void LoadShootableObj()
    {
        if (shootableObjsProfileSO != null) return;
        string resPath = "ShootableObject/" + this.GetObjectTypeString()+"/"+transform.name;
        this.shootableObjsProfileSO =Resources.Load<ShootableObjsProfileSO>(resPath);
    }
    protected abstract string GetObjectTypeString();


    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = transform.parent?.parent?.GetComponent<Spawner>();
    }

    protected virtual void LoadDameReceiver()
    {
        if(dameReceiver != null) return;
        dameReceiver = GetComponentInChildren<DameReceiver>();
    }
    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = GetComponentInChildren<Despawn>();
    }
}
