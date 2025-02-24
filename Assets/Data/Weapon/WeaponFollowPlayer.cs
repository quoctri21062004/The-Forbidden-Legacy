using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowPlayer : TrisMonoBehaviour
{
    [Header("Weapon Follow Player")]
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed = 30f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        GameObject playerS = GameObject.FindGameObjectWithTag("Player");
        player = playerS.transform;
    }

    protected virtual void Following()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, player.position, speed * Time.fixedDeltaTime);
    }
}
