using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : TrisMonoBehaviour
{
    [Header("Weapon Ctrl")]
    private static WeaponCtrl instance;
    public static WeaponCtrl Instance => instance;

    [SerializeField] protected Transform model;
    public Transform Model => model;

    protected override void Awake()
    {
        base.Awake();
        if (WeaponCtrl.instance != null) Debug.LogError("Only 1 WeaponCtrl allow to exist");
        WeaponCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
    }
}
