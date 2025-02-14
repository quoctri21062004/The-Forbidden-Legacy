using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : TrisMonoBehaviour
{
    [Header("Player Animation")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isMoving;
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
    protected virtual bool CheckIsMoving()
    {
        Vector4 playerDirection = InputManager.Instance.Direction;
        if ((playerDirection.x != 0 || playerDirection.y != 0 
            || playerDirection.z != 0 || playerDirection.w != 0)) return true;
        return false;
    }
    protected virtual void IdieToMoving()
    {
        //Vector2 playerDirection = InputManager.Instance.Direction;
        //animator.SetFloat("moveX", Mathf.Abs((float)playerDirection.x));
        //animator.SetFloat("moveY", Mathf.Abs((float)playerDirection.y));
        animator.SetBool("move", CheckIsMoving());
    }
}
