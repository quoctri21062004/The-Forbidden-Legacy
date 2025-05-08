using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFireAnimation : TrisMonoBehaviour
{
    [Header("SoulFire Animation")]
    [SerializeField] protected Animator animator;

    public Animator Animator => animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
    }

    public virtual void FXRun()
    {
        animator.SetBool("Finish", true);
    }
}
