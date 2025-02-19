using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollowTarget : TrisMonoBehaviour
{
    [Header("Follow Target")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected  virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, speed*Time.fixedDeltaTime);
    }


}
