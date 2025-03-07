using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public ChaseState(EnemyStateMachine enemy) : base(enemy) { }

    public override void EnterState()
    {
        enemyStateMachine.Animator.SetBool("IsRunning", true);
    }

    public override void UpdateState()
    {
        enemyCtrl.EnemyMovement.gameObject.SetActive(true);

        if (enemyCtrl.EnemyAttack.CanAttack())
        {
            enemyStateMachine.ChangeState(new AttackState(enemyStateMachine));
        }
    }

    public override void ExitState()
    {
        //
    }
}
