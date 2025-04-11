using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    [SerializeField] protected BulletCtrl bulletCtrl;
    

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
        {
            Debug.LogError("Only 1 BulletSpawner allow to exist");
        }
        BulletSpawner.instance = this;

    }

    public string GetNameBullet()
    {
        if (bulletCtrl == null || bulletCtrl.WeaponProfile == null || bulletCtrl.WeaponProfile.ammoProfile == null)
        {
            Debug.LogWarning("bulletCtrl or its profile is null!");
            return string.Empty;
        }
        foreach (var prefab in prefabs)
        {
            if (prefab.name != bulletCtrl.WeaponProfile.ammoProfile.name)continue;
             return prefab.name;
        }
        return string.Empty;
    }
}
