using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    public IdleState(EnemyStateMachine enemy) : base(enemy) { }

    public override void EnterState()
    {
        enemyCtrl.EnemyAnimation.EnemyIdleAnim();
    }

    public override void UpdateState()
    {
        if (enemyCtrl.EnemyAttack.CanAttack())
        {
            enemyStateMachine.ChangeState(EnemyStateType.Attack);
        }

        if (enemyCtrl.EnemyDetection.Trigger)
        {
            enemyStateMachine.ChangeState(EnemyStateType.Chase);
        }
        if (enemyCtrl.EnemyMovement.CanMove())
        {
            enemyStateMachine.ChangeState(EnemyStateType.Chase);
        }
    }

    public override void ExitState()
    {
        //
    }
}
