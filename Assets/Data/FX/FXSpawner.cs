using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string fxOne = "FXSoulFire";

    [SerializeField] protected FXCtrl fXCtrl;
    public FXCtrl FXCtrl=>fXCtrl;
    [SerializeField] public Transform soulFire;


    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null)
        {
            Debug.LogError("Only 1 FXSpawner allow to exist");
        }
        FXSpawner.instance = this;
    }
  
}
