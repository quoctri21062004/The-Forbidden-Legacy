using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : Spawner
{
    [Header("Ally Spawner")]
    private static AllySpawner instance;
    public static AllySpawner Instance => instance;

    [SerializeField] protected List<AllyMapping> allyMappings;
    [SerializeField] protected Dictionary<EnemyType, GameObject> typeToAllyPrefab;
    protected override void Awake()
    {
        base.Awake();
        if (AllySpawner.instance != null)
        {
            Debug.LogError("Only 1 AllySpawner allow to exist");
        }
        AllySpawner.instance = this;

        InitializeAllyMapping();
    }

    protected virtual void InitializeAllyMapping()
    {
        typeToAllyPrefab = new Dictionary<EnemyType, GameObject>();
        foreach(var mapping in allyMappings)
        {
            typeToAllyPrefab[mapping.enemyType]= mapping.allyPrefab;
        }
    }

    public virtual GameObject SpawnAlly(EnemyType enemyType,Vector3 pos)
    {
        if(typeToAllyPrefab.TryGetValue(enemyType, out GameObject prefab))
        {
            Transform allyPrefab = Spawn(prefab.transform, pos, Quaternion.identity);
            return allyPrefab?.gameObject;
        }
        Debug.LogWarning("Không tìm thấy AllyPrefab tương ứng với EnemyType: " + enemyType);
        return null;
    }
}
