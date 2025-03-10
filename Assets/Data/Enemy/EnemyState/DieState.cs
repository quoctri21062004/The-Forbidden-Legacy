using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : EnemyState
{
    [SerializeField] private AnimationClip dieClip;
    public DieState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) { }

    public override void EnterState()
    {
        enemyCtrl.MushroomAnimation.MushroomDieAnim();
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
