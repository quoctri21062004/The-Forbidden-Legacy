using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollowTarget : TrisMonoBehaviour
{
    [Header("Follow Target")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected override void Start()
    {
        base.Start();
        this.SetTarget();
    }
    protected virtual void Update()
    {
        this.Following();
    }

    protected  virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, speed*Time.deltaTime);
    }
    protected virtual void SetTarget()
    {
       //
    }

}
