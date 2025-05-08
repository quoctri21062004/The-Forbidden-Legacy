using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
   // [Header("FX Despawn")]
    protected virtual void DespawnFXByTime()
    {
        if(!CanDespawn()) return;
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
