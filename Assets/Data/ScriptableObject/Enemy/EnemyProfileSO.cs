using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProfile", menuName = "SO/EnemyProfile")]
public class EnemyProfileSO : ShootableObjsProfileSO
{
    [Header("Enemy ProfileSO")]
    public bool isSpawner;
    public EnemyType enemyType;
}
