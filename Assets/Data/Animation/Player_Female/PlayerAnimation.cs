using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : TrisMonoBehaviour
{
    [Header("Player Animation")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isMoving;
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected Vector2 lastMoveDirection = Vector2.down;


    protected virtual void Update()
    {
        this.PlayerDirection();
        this.PlayerAnim();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = GetComponentInParent<PlayerCtrl>();
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + " :LoadAnimator", gameObject);
    }
    public virtual void PlayerDirection()
    {
        Vector2 playerDirection = InputManager.Instance.Direction;
        isMoving = playerDirection != Vector2.zero;
        if (isMoving)
        {
           lastMoveDirection = playerDirection.normalized;
        }
    }
    protected virtual void PlayerAnim()
    {
        animator.SetBool("move", playerCtrl.PlayerMovement.CheckIsMoving());
        animator.SetFloat("moveX", isMoving ? InputManager.Instance.Direction.x : lastMoveDirection.x);
        animator.SetFloat("moveY", isMoving ? InputManager.Instance.Direction.y : lastMoveDirection.y);
    }
}
