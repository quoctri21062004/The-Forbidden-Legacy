using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DameReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
    }
    protected override void OnDead()
    {
        Debug.Log(transform.parent.name + " IS DEAD");
    }
}
