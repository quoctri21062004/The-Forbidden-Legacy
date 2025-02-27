using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistane
{
    public override void DespawnObject()
    {
      EnemySpawner.Instance.Despawn(transform.parent);
    }
}
