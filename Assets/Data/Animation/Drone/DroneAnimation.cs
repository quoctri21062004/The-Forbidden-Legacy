using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAnimation : TrisMonoBehaviour
{
    [Header("Drone Animation")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected Vector2 previousPosition;
    [SerializeField] protected Transform model;
    protected virtual void Update()
    {
        this.DroneAnim();
        this.DroneShooting();
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
    protected virtual void DroneAnim()
    {
        Vector2 droneDirection = (Vector2)transform.position - (Vector2)previousPosition;
        bool isMoving = Mathf.Abs(droneDirection.x) > 0.01f;

        animator.SetBool("move", isMoving);

        if (isMoving)
        {
            float moveX = droneDirection.x > 0 ? 1 : -1; 
            animator.SetFloat("moveX", moveX);

            if (Mathf.Sign(model.localScale.x) != moveX)
            {
                model.localScale = new Vector3(moveX * Mathf.Abs(model.localScale.x), model.localScale.y, model.localScale.z);
            }
        }

        previousPosition = transform.position;

    }
    public virtual void DroneShooting()
    {
       animator.SetBool("shoot",true);
    }
}
