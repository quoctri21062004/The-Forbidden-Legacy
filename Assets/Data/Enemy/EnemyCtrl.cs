using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : ShootableObjectCtrl
{
    //[Header("EnemyCtrl")]
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement =>enemyMovement;

    [SerializeField] protected EnemyAttack enemyAttack;
    public EnemyAttack EnemyAttack => enemyAttack;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyMovement();
        this.LoadEnemyAttack();
    }

    protected virtual void LoadEnemyMovement()
    {
        if (enemyMovement != null) return;
        enemyMovement = GetComponentInChildren<EnemyMovement>();
    }
    protected virtual void LoadEnemyAttack()
    {
        if (enemyAttack != null) return;
        enemyAttack = GetComponentInChildren<EnemyAttack>();
    }
    protected override string GetObjectTypeString()
    {
        return ShootableObjsType.Enemy.ToString();
    }
}
