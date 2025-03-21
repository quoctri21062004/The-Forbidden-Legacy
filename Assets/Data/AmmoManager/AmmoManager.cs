using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : TrisMonoBehaviour
{
    [Header("Ammo Manager")]

    private static AmmoManager instance;
    public static AmmoManager Instance => instance;

    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    [SerializeField] protected int currentAmmo;
    [SerializeField] protected int maxAmmo = 30;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeReload = 3f;

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
    protected virtual void Update()
    {
        this.AddAmmo();
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

    public virtual bool CanReloadAmmo()
    {
        if (currentAmmo >= maxAmmo) return false;
        return true;
    }
    public virtual void AddAmmo()
    {
        if (!CanReloadAmmo()) return;

        //int ammoAdd = GetAmmoFromInventory();
        //if (ammoAdd <= 0) return; 
    
        if(LoadAmmoManually()) return;
        LoadAmmoAuto();
    }

    protected virtual int GetAmmoFromInventory()
    {
        int ammoNeeded = maxAmmo - currentAmmo;
        return inventory.DeductItem(ItemCode.Ammo, ammoNeeded);
    }

    protected virtual bool LoadAmmoManually()
    {
      //  int ammoAdd = GetAmmoFromInventory();
        if (InputManager.Instance.GetReloadAmmo())
        {
            int ammoAdd = GetAmmoFromInventory();
            currentAmmo += ammoAdd;
            Debug.Log("Thay dan bang R");
            return true;
        }
        return false;
    }
    protected virtual void LoadAmmoAuto()
    {
        if (CheckHasAmmo()) return;
       
        timer += Time.fixedDeltaTime;
        if (timer < timeReload) return;
        timer = 0f;

        int ammoAdd = GetAmmoFromInventory();
        currentAmmo += ammoAdd;
        Debug.Log("Thay dan tu dong sau 3s");
    }
    public virtual int GetAmmo()
    {
        return currentAmmo;
    }


}
