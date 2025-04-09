using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjFollowPlayer : ObjFollowTarget
{
    [Header("Obj Follow Player")]
    [SerializeField] protected float limitDistance = 1.6f;
    [SerializeField] protected float distance = 0f;

    protected override void Following()
    {
        if (this.target == null) return;
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < limitDistance) return;

        Vector3 direction = (target.position - transform.position).normalized;

        Vector3 targetPosition = target.position - direction * limitDistance;

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.fixedDeltaTime);

    }
}
