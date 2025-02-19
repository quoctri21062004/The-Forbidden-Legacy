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
    protected virtual void Update()
    {
        this.IdieToMoving();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();

    }

    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + " :LoadAnimator", gameObject);
    }
    protected virtual void IdieToMoving()
    {
        Vector2 playerDirection = InputManager.Instance.Direction;
        animator.SetFloat("moveX", playerDirection.x);
        animator.SetFloat("moveY", playerDirection.y);

        animator.SetBool("move", PlayerCtrl.Instance.PlayerMovement.CheckIsMoving());

    }

    
}
