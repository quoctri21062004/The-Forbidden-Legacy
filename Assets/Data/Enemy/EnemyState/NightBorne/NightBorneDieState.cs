using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneDieState : DieState
{
    public NightBorneDieState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)  { }

    public override void UpdateState()
    {
        base.UpdateState();

        if (!enemyCtrl.EnemyDamageReceiver.IsDead()) return;
        enemyStateMachine.ChangeState(EnemyStateType.Destroy);
    }
}
