using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySetup : MonoBehaviour ,IEnemySetup
{
    public void Setup(EnemyCtrl enemy)
    {
        enemy.EnemySpawner.enabled = true;
        enemy.EnemyDetection.enabled = false;
        enemy.EnemyMovement.enabled = true;
    }

  
}
