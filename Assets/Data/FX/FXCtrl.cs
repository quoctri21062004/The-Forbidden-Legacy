using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXCtrl : TrisMonoBehaviour
{
    [Header("FXCtrl")]
    [SerializeField] protected Transform model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = GetComponentInChildren<Transform>();
    }
}
