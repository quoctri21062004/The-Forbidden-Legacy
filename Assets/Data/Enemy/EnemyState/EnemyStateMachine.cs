using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : EnemyAbstract
{
    [Header("Enemy State Machine")]
    [SerializeField] public EnemyState currentState;
    [SerializeField] public Animator animator;
    public Animator Animator => animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if(animator != null)return;
        animator = transform.GetComponentInChildren<Animator>();
    }
    protected override void Start()
    {
        ChangeState(new IdleState(this));  // Bắt đầu với trạng thái Idle
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
