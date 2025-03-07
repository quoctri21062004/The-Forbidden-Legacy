using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField] protected bool isAttacking = false;
    [SerializeField] protected float attackCooldown = 3f;
    [SerializeField] protected float lastAttackTime;

    public AttackState(EnemyStateMachine enemy) : base(enemy) { }

    public override void EnterState()
    {
        if (isAttacking) return;
        isAttacking = true;
       
        enemyCtrl.MushroomAnimation.MushroomAttackAnim();
        lastAttackTime = Time.time;
        enemyCtrl.EnemyDamageSender.gameObject.SetActive(true);

        enemyStateMachine.StartCoroutine(ResetAfterAttack());
    }

    public override void ExitState()
    {
        enemyStateMachine.Animator.SetBool("IsAttack", false);
        isAttacking = false;
    }

    public override void UpdateState()
    {
        if (!isAttacking && enemyCtrl.EnemyAttack.CanAttack() && Time.time - lastAttackTime >= attackCooldown)
        {
            isAttacking = true;
            lastAttackTime = Time.time;
            enemyCtrl.MushroomAnimation.MushroomAttackAnim();
            Debug.Log("Bật EnemyDamageSender");
            enemyCtrl.EnemyDamageSender.gameObject.SetActive(true);

            enemyStateMachine.StartCoroutine(ResetAfterAttack());
        }
    }

    private IEnumerator ResetAfterAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        enemyCtrl.EnemyAttack.ResetDetection();

        isAttacking = false;
        enemyCtrl.EnemyDamageSender.gameObject.SetActive(false);
        Debug.Log("ResetAfterAttack chạy, tắt EnemyDamageSender");
    }
}
