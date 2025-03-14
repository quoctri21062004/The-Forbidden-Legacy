using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : EnemyAbstract
{
    [Header("Enemy State Machine")]
    [SerializeField] public EnemyState currentState;

    protected override void Start()
    {
        ChangeState(new IdleState(this)); 
    }

    protected virtual void Update()
    {
        currentState?.UpdateState();
    }

    public virtual void ChangeState(EnemyState newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
