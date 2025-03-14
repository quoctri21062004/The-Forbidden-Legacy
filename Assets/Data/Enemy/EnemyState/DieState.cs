using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : EnemyState
{
    public DieState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) { }

    public override void EnterState()
    {
        enemyCtrl.MushroomAnimation.MushroomDieAnim();
        var deathHandler = enemyCtrl.GetComponent<EnemyDeathHandler>();
        if (deathHandler == null) return;
        deathHandler.HandleDeath();

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
