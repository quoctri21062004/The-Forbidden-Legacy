using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCtrl : ShootableObjectCtrl
{
    [Header("EnemyCtrl")]
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement =>enemyMovement;

    [SerializeField] protected EnemyAttack enemyAttack;
    public EnemyAttack EnemyAttack => enemyAttack;

    [SerializeField] protected EnemyDetection enemyDetection;
    public EnemyDetection EnemyDetection => enemyDetection;

    [SerializeField] protected MushroomAnimation mushroomAnimation;
    public MushroomAnimation MushroomAnimation => mushroomAnimation;

    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    public EnemyDamageSender EnemyDamageSender => enemyDamageSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyMovement();
        this.LoadEnemyAttack();
        this.LoadEnemyDetection();
        this.LoadEnemyDamageSender();
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
    protected virtual void LoadEnemyDetection()
    {
        if (enemyDetection != null) return;
        enemyDetection = GetComponentInChildren<EnemyDetection>();
    }
    protected virtual void LoadEnemyDamageSender()
    {
        if (EnemyDamageSender != null) return;
        enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
    }
    protected override string GetObjectTypeString()
    {
        return ShootableObjsType.Enemy.ToString();
    }
}
