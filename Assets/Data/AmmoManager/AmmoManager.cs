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
        if (!InputManager.Instance.GetReloadAmmo()) return; 

        int ammoNeeded = maxAmmo - currentAmmo; 
        int ammoToDeduct = inventory.DeductItem(ItemCode.Ammo, ammoNeeded);

        if (ammoToDeduct <= 0)
        {
            Debug.Log("Không có đạn để nạp!");
            return;
        }
        currentAmmo += ammoToDeduct; 
        Debug.Log($"Nạp thành công {ammoToDeduct} viên. Đạn hiện tại: {currentAmmo}/{maxAmmo}");
    }
    public virtual int GetAmmo()
    {
        return currentAmmo;
    }


}
