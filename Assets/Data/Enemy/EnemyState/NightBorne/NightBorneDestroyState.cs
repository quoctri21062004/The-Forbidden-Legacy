using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneDestroyState : DestroyState
{
    public NightBorneDestroyState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) { }

    public override void EnterState()
    {
        Debug.Log("Enemy bi pha huy sau khi chet");
        base.EnterState();
        Debug.Log("Enemy da bi pha huy sau khi chet");
    }
}
