using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : ShootableObjectDameReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] private EnemyStateMachine enemyStateMachine;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyStateMachine();
    }
    protected virtual void LoadEnemyStateMachine()
    {
        if(enemyStateMachine != null) return;
        enemyStateMachine = transform.parent.GetComponentInChildren<EnemyStateMachine>();
    }
    protected override void OnDead()
    {
        enemyStateMachine.ChangeState(EnemyStateType.Die);
    }
}
