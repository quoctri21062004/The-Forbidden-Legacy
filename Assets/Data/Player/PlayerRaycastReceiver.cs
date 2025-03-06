using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastReceiver : TrisMonoBehaviour
{
    [Header("Player Raycast Receiver")]
    [SerializeField] protected Collider2D collider2;
    public Collider2D Collider2 => collider2;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (collider2 != null) return;
        collider2 = GetComponent<Collider2D>();
    }
}
