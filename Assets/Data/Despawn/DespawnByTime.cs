using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [Header("Despawn By Time")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float time = 2f;
    protected override bool CanDespawn()
    {
        timer += Time.deltaTime;
        if (timer > time) return false;
        timer = 0f;
        return true;
    }
}
