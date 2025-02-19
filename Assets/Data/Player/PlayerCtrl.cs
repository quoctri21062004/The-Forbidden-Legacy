using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : TrisMonoBehaviour
{
    [Header("Player Ctrl")]
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;

    [SerializeField] protected Transform targetPoint;
    public Transform TargetPoint => targetPoint;


    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerMovement();
        this.LoadTarget();

    }
    protected virtual void LoadPlayerMovement()
    {
        if (playerMovement != null) return;
        playerMovement = transform.GetComponentInChildren<PlayerMovement>();
        Debug.LogWarning(transform.name + " :LoadPlayerMovement", gameObject);
    }
    protected virtual void LoadTarget()
    {
        if (this.targetPoint != null) return;
        targetPoint = transform.Find("TargetPoint");
        Debug.LogWarning(transform.name + " :LoadTarget", gameObject);

    }




}
