using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistane : Despawn
{
    [Header("Despawn by distane")]
    [SerializeField] protected float maxDistane = 70f;
    [SerializeField] protected float distane = 0f;
    [SerializeField] protected GameObject mainCamera;

    protected virtual void LoadComponent()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Debug.LogWarning(transform.name + " :LoadCamera", gameObject);
    }

    protected override bool CanDespawn()
    {
       this.distane = Vector3.Distance(transform.position, mainCamera.transform.position);
        if (distane > maxDistane) return true;
        return false;
    }
}
