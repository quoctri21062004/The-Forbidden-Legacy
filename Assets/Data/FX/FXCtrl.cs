using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXCtrl : TrisMonoBehaviour
{
    [Header("FXCtrl")]
    [SerializeField] protected Transform model;
    [SerializeField] protected SoulFireAnimation soulFireAnimation;
    public SoulFireAnimation SoulFireAnimation => soulFireAnimation;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadAnimation();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = GetComponentInChildren<Transform>();
    }
    protected virtual void LoadAnimation()
    {
        if (soulFireAnimation != null) return;
        soulFireAnimation = GetComponentInChildren<SoulFireAnimation>();
    }
}
