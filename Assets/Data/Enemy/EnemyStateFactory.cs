using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFactory
{
    public static EnemyState CreateState(EnemyStateType stateType, EnemyStateMachine enemyStateMachine)
    {
        EnemyType enemyType = enemyStateMachine.EnemyProfileSO.enemyType;
        switch (enemyStateMachine.EnemyProfileSO.enemyType)
        {
            case EnemyType.Mushroom:
                return CreateMushroomState(stateType, enemyStateMachine);
            case EnemyType.NightBorne:
                return CreateNightBorneState(stateType, enemyStateMachine);
            default:
                return CreateDefaultState(stateType, enemyStateMachine);
        }
    }
    private static EnemyState CreateMushroomState(EnemyStateType stateType, EnemyStateMachine enemyStateMachine)
    {
        return stateType switch
        {
            EnemyStateType.Idle => new MushroomIdleState(enemyStateMachine),
            EnemyStateType.Chase => new MushroomChaseState(enemyStateMachine),
            EnemyStateType.Attack => new MushroomAttackState(enemyStateMachine),
            EnemyStateType.Die => new MushroomDieState(enemyStateMachine),
            _ => null
        };
    }

    private static EnemyState CreateNightBorneState(EnemyStateType stateType, EnemyStateMachine enemyStateMachine)
    {
        return stateType switch
        {
            EnemyStateType.Idle => new NightBorneIdleState(enemyStateMachine),
            EnemyStateType.Chase => new NightBorneChaseState(enemyStateMachine),
            EnemyStateType.Attack => new NightBorneAttackState(enemyStateMachine),
            EnemyStateType.Die => new NightBorneDieState(enemyStateMachine),
            EnemyStateType.Destroy=> new NightBorneDestroyState(enemyStateMachine),
            _ => null
        };
    }

    private static EnemyState CreateDefaultState(EnemyStateType stateType, EnemyStateMachine enemyStateMachine)
    {
        return stateType switch
        {
            EnemyStateType.Idle => new IdleState(enemyStateMachine),
            EnemyStateType.Chase => new ChaseState(enemyStateMachine),
            EnemyStateType.Attack => new AttackState(enemyStateMachine),
            EnemyStateType.Die => new DieState(enemyStateMachine),
            _ => null
        };
    }
}
