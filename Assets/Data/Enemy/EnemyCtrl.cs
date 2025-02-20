using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : TrisMonoBehaviour
{
   [Header("EnemyCtrl")]
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (enemySpawner != null) return;
        enemySpawner = GameObject.FindAnyObjectByType<EnemySpawner>().GetComponent<EnemySpawner>();
    }


}
