using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerDrone : TrisMonoBehaviour
{
    [Header("Spawn PlayerDrone")]
    [SerializeField] protected Transform dronePrefab;
    [SerializeField] public Transform targetPoint;
    protected override void Start()
    {
        base.Start();
        this.SpanwDrone();
    }
    protected virtual void SpanwDrone()
    {
        dronePrefab = DroneSpawner.Instance.Spawn(dronePrefab, transform.position, Quaternion.identity);
        dronePrefab.transform.SetParent(transform); 
    }

}
