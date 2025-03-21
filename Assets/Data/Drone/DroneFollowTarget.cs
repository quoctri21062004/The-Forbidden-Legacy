using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DroneFollowTarget : ObjFollowTarget
{
    [Header("Follow Target")]
    [SerializeField] protected Transform player;
    [SerializeField] protected float distanceLimit = 1f;
    [SerializeField] protected float distance;


    protected override void Start()
    {
        base.Start();
        this.SetTarget();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        player = _player.transform;
    }

    protected override void Following()
    {
        this.distance = Vector3.Distance(this.player.transform.position, transform.parent.position);
        if (distance < distanceLimit) return;
        transform.parent.position = Vector3.Lerp(transform.parent.position, target.position, speed * Time.fixedDeltaTime);
    }
    protected override void SetTarget()
    {
        this.target = this.player;
    }
}
