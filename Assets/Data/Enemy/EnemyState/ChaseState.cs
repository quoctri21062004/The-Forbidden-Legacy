using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public ChaseState(EnemyStateMachine enemy) : base(enemy) { }

    public override void EnterState()
    {
        enemyCtrl.MushroomAnimation.MushroomMovingAnim();
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
