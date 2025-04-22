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

    [SerializeField] protected BaseEnemyAnimation enemyAnimation;
    public BaseEnemyAnimation EnemyAnimation => enemyAnimation;

    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    public EnemyDamageSender EnemyDamageSender => enemyDamageSender;

    [SerializeField] protected EnemyStateMachine enemyStateMachine;
    public EnemyStateMachine EnemyStateMachine => enemyStateMachine;

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;

    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;

    [SerializeField] protected EnemyProfileSO enemyProfile;

    [SerializeField] protected NightBorneAnimation nightBorneAnimation;
    public NightBorneAnimation NightBorneAnimation => nightBorneAnimation;

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
        this.LoadEnemyAnimation();
        this.LoadEnemyProfile();
        this.LoadEnemySpawner();
        this.LoadNightBorneAnimation();
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
    protected virtual void LoadEnemyAnimation()
    {
        if(enemyAnimation != null) return;
        Transform model = transform.Find("Model");
        enemyAnimation = model.GetComponent<BaseEnemyAnimation>();
    }

    protected virtual void LoadEnemyProfile()
    {
        if (shootableObjsProfileSO != null && shootableObjsProfileSO.objType == ShootableObjsType.Enemy)
        {
            EnemyProfileSO enemySO = shootableObjsProfileSO as EnemyProfileSO;

            if (enemySO != null)
            {
                this.enemyProfile = enemySO;
            }
            else
            {
                Debug.LogWarning($"ShootableObjsProfileSO không phải là EnemyProfileSO: {shootableObjsProfileSO.name}");
            }
        }
    }

    protected virtual void LoadNightBorneAnimation()
    {
        if (nightBorneAnimation != null) return;
        Transform model = transform.Find("Model");
        nightBorneAnimation = model.GetComponent<NightBorneAnimation>();
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
