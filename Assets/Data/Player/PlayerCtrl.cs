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

    [SerializeField] protected SpawnPlayerDrone playerDrone;
    public SpawnPlayerDrone PlayerDrone => playerDrone;

    [SerializeField] protected PlayerDroneMovement playerDroneMovement;
    public PlayerDroneMovement PlayerDroneMovement => playerDroneMovement;

    [SerializeField] protected PlayerAttack playerAttack;
    public PlayerAttack PlayerAttack => playerAttack;

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
        this.LoadPlayerDrone();
        this.LoadPlayerDroneMovement();
        this.LoadPlayerAttack();


    }
    protected virtual void LoadPlayerMovement()
    {
        if (playerMovement != null) return;
        playerMovement = transform.GetComponentInChildren<PlayerMovement>();
        Debug.LogWarning(transform.name + " :LoadPlayerMovement", gameObject);
    }
    protected virtual void LoadPlayerAttack()
    {
        if (playerAttack != null) return;
        playerAttack = transform.GetComponentInChildren<PlayerAttack>();
        Debug.LogWarning(transform.name + " :LoadPlayerAttack", gameObject);
    }

    protected virtual void LoadPlayerDrone()
    {
        if (this.playerDrone != null) return;
        playerDrone = GetComponentInChildren<SpawnPlayerDrone>();
        Debug.LogWarning(transform.name + " :LoadPlayerDrone", gameObject);
    }
    protected virtual void LoadPlayerDroneMovement()
    {
        if (playerDroneMovement != null) return;
        playerDroneMovement = transform.GetComponentInChildren<PlayerDroneMovement>();
    }
}
