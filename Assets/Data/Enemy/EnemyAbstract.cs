using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : TrisMonoBehaviour
{
    [Header("Enemy Abstract")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = GetComponent<EnemyCtrl>();
    }
}
