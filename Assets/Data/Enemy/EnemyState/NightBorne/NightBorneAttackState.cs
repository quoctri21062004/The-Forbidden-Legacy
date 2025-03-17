using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAttackState : AttackState
{
    public NightBorneAttackState(EnemyStateMachine enemy) : base(enemy) { }
    public override void EnterState()
    {
        Debug.Log("NightBorne bat dau Attack");
        base.EnterState();
    }
}
