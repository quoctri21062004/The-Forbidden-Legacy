using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("Enemy Spawner")]
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    public static string enemyOne = "Enemy_1";
    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null)
        {
            Debug.LogError("Only 1 EnemySpawner allow to exist");
        }
        EnemySpawner.instance = this;
    }
    public virtual Transform RandomPrefabs()
    {
        int rand = Random.Range(0,prefabs.Count);
        return this.prefabs[rand];
    }
  
}
