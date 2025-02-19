using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : TrisMonoBehaviour
{
    [Header("DameSender")]
    [SerializeField] protected float damage = 1f;
    public virtual void Send(Transform obj)
    {
        DameReceiver damageReceiver = obj.GetComponentInChildren<DameReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DameReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
}
