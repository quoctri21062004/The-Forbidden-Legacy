using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DroneSpawner : Spawner
{
    private static DroneSpawner instance;
    public static DroneSpawner Instance { get => instance; }

    public static string droneOne = "Drone_1";

    protected override void Awake()
    {
        base.Awake();
        if (DroneSpawner.instance != null)
        {
            Debug.LogError("Only 1 DroneSpawner allow to exist");
        }
        DroneSpawner.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
 
}
