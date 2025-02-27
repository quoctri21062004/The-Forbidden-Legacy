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
    protected virtual void PlayerAnim()
    {
        Vector2 playerDirection = InputManager.Instance.Direction;
        isMoving = playerDirection != Vector2.zero;
        if (isMoving)
        {
            lastMoveDirection = playerDirection.normalized;
        }
        animator.SetBool("move", playerCtrl.PlayerMovement.CheckIsMoving());
        animator.SetFloat("moveX", playerDirection.x);
        animator.SetFloat("moveY", playerDirection.y);
        if (!isMoving)
        {
            animator.SetFloat("moveX", lastMoveDirection.x);
            animator.SetFloat("moveY", lastMoveDirection.y);
        }
    }
}
