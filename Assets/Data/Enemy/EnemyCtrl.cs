using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : ShootableObjectCtrl
{
    //[Header("EnemyCtrl")]
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement =>enemyMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyMovement();
    }

    protected virtual void LoadEnemyMovement()
    {
        if (enemyMovement != null) return;
        enemyMovement = GetComponentInChildren<EnemyMovement>();
    }
    protected override string GetObjectTypeString()
    {
        return ShootableObjsType.Enemy.ToString();
    }
}
