using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandom : TrisMonoBehaviour
{
    [Header("Enemy Spawn Random")]
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected SpawnPoints spawnPoints;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;

    protected virtual void FixedUpdate()
    {
        this.EnemySpawning();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        enemySpawner = transform.GetComponent<EnemySpawner>();
        Debug.LogWarning(transform.name + " :LoadEnemySpawner", gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if(this.spawnPoints != null) return;
        spawnPoints = GetComponent<SpawnPoints>();
        Debug.Log(transform.name + " :LoadSpawnPoints", gameObject);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentEnemy = this.enemySpawner.SpawnedCount;
        return currentEnemy>=this.randomLimit;
    }

    protected virtual void EnemySpawning()
    {
        if (RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = spawnPoints.RandomPoint();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.enemySpawner.RandomPrefabs();
        Transform obj = this.enemySpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

}
