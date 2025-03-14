using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalEnemySetup : MonoBehaviour,IEnemySetup
{
    public void Setup(EnemyCtrl enemy)
    {
        enemy.EnemySpawner.enabled = false;
        enemy.EnemyDetection.enabled = true;
        enemy.EnemyMovement.enabled = false;
    }

    
}
