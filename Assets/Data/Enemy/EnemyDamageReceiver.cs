using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : ShootableObjectDameReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] private EnemyStateMachine enemyStateMachine;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyStateMachine();
    }
    protected virtual void LoadEnemyStateMachine()
    {
        if(enemyStateMachine != null) return;
        GameObject stateMachine = GameObject.Find("EnemyStateMachine");
        enemyStateMachine = stateMachine.GetComponent<EnemyStateMachine>();
    }
    protected override void OnDead()
    {
        enemyStateMachine.ChangeState(new DieState(enemyStateMachine));

        float dieTime = enemyStateMachine.EnemyCtrl.MushroomAnimation.GetDieAnimationLength();
        StartCoroutine(WaitForDeath(dieTime));
        base.OnDead();
    }

    private IEnumerator WaitForDeath(float time)
    {
        yield return new WaitForSeconds(time);

        //this.DropItemOnDead();

        //enemyStateMachine.EnemyCtrl.Spawner.Despawn(transform);
    }
}
