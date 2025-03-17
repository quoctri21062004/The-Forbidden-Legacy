using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : EnemyAbstract
{
    [Header("Enemy State Machine")]
    [SerializeField] public EnemyState currentState;
    [SerializeField] private EnemyStateType initialState;
    [SerializeField] protected ShootableObjsProfileSO enemyProfileSO;
    public ShootableObjsProfileSO EnemyProfileSO =>enemyProfileSO;

    protected override void Start()
    {
        //  ChangeState(new IdleState(this)); 
        //ChangeState(EnemyStateType.Idle);
        ChangeState(initialState);
    }

    protected virtual void Update()
    {
        currentState?.UpdateState();
    }

    public virtual void ChangeState(EnemyStateType newState)
    {
        if (!gameObject.activeSelf) return;
        currentState?.ExitState();
        currentState = EnemyStateFactory.CreateState(newState,this );
        currentState.EnterState();
    }
}
