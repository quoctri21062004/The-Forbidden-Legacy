using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : TrisMonoBehaviour
{
    [Header("Enemy Movement")]
    [SerializeField] protected float moveSpeed =20f; 
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;
    [SerializeField] protected Transform target;
    [SerializeField] protected Vector3 targetPosition;

    protected virtual void FixedUpdate()
    {
        this.GetTargetPosition();
        this.Moving();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadTarget();
    }

    protected virtual void LoadTarget()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        this.SetTarget(target.transform);
    }

    protected virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void GetTargetPosition()
    {
        if (this.target == null) return;
        this.targetPosition = this.target.position;
        this.targetPosition.z = 0;
    }
    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, targetPosition);
        if (this.distance < minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition,this.moveSpeed);
        transform.parent.position = newPos;
    }
}
