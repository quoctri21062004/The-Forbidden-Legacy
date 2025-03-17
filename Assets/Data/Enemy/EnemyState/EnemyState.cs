using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    [Header("Enemy State")]
    [SerializeField]protected EnemyStateMachine enemyStateMachine;
    [SerializeField]protected EnemyCtrl enemyCtrl;
    [SerializeField] protected BaseEnemyAnimation enemyAnimation;
    public EnemyState (EnemyStateMachine enemyStateMachine)
    {
        this.enemyStateMachine = enemyStateMachine;
        this.enemyCtrl = enemyStateMachine.EnemyCtrl;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
