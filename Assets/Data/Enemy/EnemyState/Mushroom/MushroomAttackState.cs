using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAttackState : AttackState
{
    public MushroomAttackState(EnemyStateMachine enemy) : base(enemy){ }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Mushroom Attack");
    }
}
