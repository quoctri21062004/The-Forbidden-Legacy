using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBase : TrisMonoBehaviour
{
    [Header("Trigger Base")]
    [SerializeField] protected Collider2D collider2;

    protected virtual void LoadCollider()
    {
        if (collider2 != null) return;
        collider2 = transform.GetComponent<Collider2D>();
    }
}
