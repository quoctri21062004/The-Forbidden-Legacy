using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : TrisMonoBehaviour
{
    [Header("Enemy Abstract")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
}
