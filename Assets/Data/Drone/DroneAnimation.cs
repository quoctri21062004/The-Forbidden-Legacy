using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAnimation : TrisMonoBehaviour
{
    [Header("Drone Animation")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected bool isMoving;
    [SerializeField] protected DroneCtrl droneCtrl;
    [SerializeField] protected Vector2 lastMoveDirection = Vector2.down;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadDroneCtrl();
    }

    protected virtual void LoadDroneCtrl()
    {
        if (droneCtrl != null) return;
        droneCtrl = GetComponentInParent<DroneCtrl>();
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + " :LoadAnimator", gameObject);
    }

}
