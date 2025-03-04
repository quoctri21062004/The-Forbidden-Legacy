using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : TrisMonoBehaviour
{
    [Header("Player Detected")]
    [SerializeField] protected CapsuleCollider2D capsuleCollider2;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
    }

    protected virtual void LoadCapsuleCollider()
    {
        if(capsuleCollider2 != null) return;
        capsuleCollider2 = GetComponent<CapsuleCollider2D>();
    }
}
