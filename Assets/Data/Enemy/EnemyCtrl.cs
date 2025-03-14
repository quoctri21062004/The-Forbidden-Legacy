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

    [SerializeField] protected EnemyStateMachine enemyStateMachine;
    public EnemyStateMachine EnemyStateMachine => enemyStateMachine;

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;

    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;

    [SerializeField] protected EnemyProfileSO enemyProfile;

    protected override void Start()
    {
        if (shootableObjsProfileSO != null && shootableObjsProfileSO.objType == ShootableObjsType.Enemy)
        {
            SetupEnemy();
        }
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyMovement();
        this.LoadEnemyAttack();
        this.LoadEnemyDetection();
        this.LoadEnemyDamageSender();
        this.LoadEnemyDamageReceiver();
        this.LoadEnemyStateMachine();
        this.LoadMushroomAnimation();
        this.LoadEnemyProfile();
        this.LoadEnemySpawner();
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
        if (enemyDamageSender != null) return;
        enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
    }

    protected virtual void LoadEnemyDamageReceiver()
    {
        if (enemyDamageReceiver != null) return;
        enemyDamageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
    }

    protected virtual void LoadEnemyStateMachine()
    {
        if (enemyStateMachine != null) return;
        GameObject stateMachine = GameObject.Find("EnemyStateMachine");
        enemyStateMachine = stateMachine.GetComponent<EnemyStateMachine>();
    }
    protected virtual void LoadMushroomAnimation()
    {
        if(mushroomAnimation != null) return;
        Transform model = transform.Find("Model");
        mushroomAnimation = model.GetComponent<MushroomAnimation>();
    }

    protected virtual void LoadEnemyProfile()
    {
        if (shootableObjsProfileSO != null && shootableObjsProfileSO.objType == ShootableObjsType.Enemy)
        {
            this.enemyProfile = shootableObjsProfileSO.enemyProfile;
        }
    }

    protected virtual void LoadEnemySpawner()
    {
        if(enemySpawner != null) return;
        enemySpawner = transform.parent?.parent?.GetComponent<EnemySpawner>();
    }
    protected virtual void SetupEnemy()
    {
        if (enemyProfile != null)
        {
            if (enemyProfile.isSpawner)
            {
                SetupSpawnerEnemy();
            }
            else
            {
                SetupNaturalEnemy();
            }
        }
    }

    protected virtual void SetupSpawnerEnemy()
    {
        enemySpawner.enabled = true;
        enemyDetection.gameObject.SetActive(false);
        EnemyMovement.gameObject.SetActive(true);
    }

    protected virtual void SetupNaturalEnemy()
    {
       // enemySpawner.enabled=false;
        enemyDetection.gameObject.SetActive(true);
        enemyMovement.gameObject.SetActive(false);
    }
    protected override string GetObjectTypeString()
    {
        return ShootableObjsType.Enemy.ToString();
    }
}
