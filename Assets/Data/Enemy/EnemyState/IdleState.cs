using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    public IdleState(EnemyStateMachine enemy) : base(enemy) { }

    public override void EnterState()
    {
        enemyCtrl.MushroomAnimation.MushroomIdleAnim();
    }

    public override void UpdateState()
    {
        if (enemyCtrl.EnemyAttack.CanAttack())
        {
            enemyStateMachine.ChangeState(new AttackState(enemyStateMachine));
            return;
        }

        if (enemyCtrl.EnemyDetection.Trigger)
        {
            enemyStateMachine.ChangeState(new ChaseState(enemyStateMachine));
        }
        if(enemyCtrl.EnemyMovement.isMoving)
        {
            enemyStateMachine.ChangeState(new ChaseState(enemyStateMachine));
        }
    }

    public override void ExitState()
    {
        //
    }
}
