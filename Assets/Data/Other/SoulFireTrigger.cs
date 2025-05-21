using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoulFireTrigger : TriggerBase
{
    [Header("SoulFire Trigger")]
    [SerializeField] protected CircleCollider2D circle;
    [SerializeField] public bool isTrigger =false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider();
    }

    protected virtual void LoadCircleCollider()
    {
        if (circle != null) return;
        circle = GetComponent<CircleCollider2D>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PlayerDetected playerDetected = other.GetComponent<PlayerDetected>();
        if(playerDetected == null) return;

        SetSoulFireInfo soulFireInfo = GetComponent<SetSoulFireInfo>();
        if (soulFireInfo != null)
        {
            SoulFireManager.Instance.currentSoulFireInfo = soulFireInfo;
            Debug.Log("Đã chạm vào SoulFire, đăng ký info để summon.");
        }
        this.isTrigger = true;


    }
}
