using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyState : EnemyState
{
    public DestroyState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) { }

    public override void EnterState()
    {
        if(!enemyCtrl.EnemyDamageReceiver.IsDead()) return;
        enemyCtrl.NightBorneAnimation.EnemyDestroyAnim();
    }

    public override void ExitState()
    {
        //
    }

    public override void UpdateState()
    {
        //
    }
}
