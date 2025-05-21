using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSoulFireInfo : TrisMonoBehaviour
{
    [Header("Set SoulFire Info")]
    [SerializeField] public EnemyType enemyType;

    public virtual void SetEnemyType(EnemyType enemy)
    {
        this.enemyType = enemy;
        Debug.Log("Đã gán enemyType cho SoulFire: " + enemy);
    }
    public virtual EnemyType GetEnemyType()
    {
        return this.enemyType;
    }

}
