using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : TrisMonoBehaviour
{
    [Header("Ammo Manager")]

    private static AmmoManager instance;
    public static AmmoManager Instance => instance;

    [SerializeField] protected int currentAmmo;
    [SerializeField] protected int maxAmmo = 30;

    protected override void Awake()
    {
        base.Awake();
        if (AmmoManager.instance != null) Debug.LogError("Only 1 AmmoManager allow to exist");
        AmmoManager.instance = this;

    }
    protected override void Start()
    {
        base.Start();
        this.SetAmmo();
    }

    public virtual int SetAmmo()
    {
       return currentAmmo = maxAmmo;
    }
    public virtual bool CheckHasAmmo()
    {
        return currentAmmo > 0;
    }
    public virtual void UseAmmo()
    {
        if (!CheckHasAmmo()) return;
        currentAmmo--;
    }
    public virtual void AddAmmo()
    {
       //TODO .......
    }
    public virtual int GetAmmo()
    {
        return currentAmmo;
    }


}
