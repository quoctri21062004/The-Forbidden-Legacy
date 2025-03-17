using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAnimation : EnemyAbstract
{
    [Header("Enemy Animation")]
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected Vector2 previousPosition;
    [SerializeField] protected bool isRunning;
    [SerializeField] protected bool isAttack;
    [SerializeField] protected Transform model;

 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = GetComponent<Animator>();
    }
    public virtual void EnemyIdleAnim()
    {
        isRunning = false;
        animator.SetBool("IsRunning", isRunning);
    }

    public virtual void EnemyMovingAnim()
    {
        Vector2 enemyDirection = (Vector2)transform.position - (Vector2)(previousPosition);

        Vector2 currentPos = transform.parent.position;
        isRunning = currentPos != (Vector2)previousPosition;
        animator.SetBool("IsRunning", isRunning);

        if (isRunning)
        {
            float moveX = enemyDirection.x > 0 ? 1 : -1;
            animator.SetFloat("moveX", moveX);

            if (Mathf.Sign(model.localScale.x) != moveX)
            {
                model.localScale = new Vector3(moveX * Mathf.Abs(model.localScale.x), model.localScale.y, model.localScale.z);
            }
        }
        previousPosition = currentPos;
    }

    public virtual void EnemyAttackAnim()
    {
        animator.SetBool("IsAttack", true);
        StartCoroutine(ResetAttackAnim());
    }
    private IEnumerator ResetAttackAnim()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("IsAttack", false);
    }

    public void EnableDamageSender()
    {
        Debug.Log("Bật EnemyDamageSender từ Animation Event!");
        enemyCtrl.EnemyDamageSender.gameObject.SetActive(true);
    }

    public void DisableDamageSender()
    {
        Debug.Log("Tắt EnemyDamageSender từ Animation Event!");
        enemyCtrl.EnemyDamageSender.gameObject.SetActive(false);
    }

    public virtual void EnemyDieAnim()
    {
        animator.SetBool("IsDie", true);
    }
}
