using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class EnemyDeathHandler : TrisMonoBehaviour
{
    [Header("Enemy Death Handler")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected EnemyStateMachine enemyStateMachine;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Transform enemyRoot;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadEnemyStateMachine();
    }
    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        Transform model = transform.Find("Model");
        animator = model.GetComponent<Animator>();
    }
    protected virtual void LoadEnemyStateMachine()
    {
        if (enemyStateMachine != null) return;
        enemyStateMachine = enemyCtrl.GetComponent<EnemyStateMachine>();
    }
  

    public void HandleDeath()
    {
        float dieTime = GetDieAnimationLength();
        StartCoroutine(WaitForDeath(dieTime));
    }

    private float GetDieAnimationLength()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        EnemyType enemyType = enemyStateMachine.EnemyProfileSO.enemyType;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name.Contains(enemyType + "_Die"))
            {
                return clip.length;
            }
        }
        return 1f;
    }

    private IEnumerator WaitForDeath(float dieTime)
    {
        yield return new WaitForSeconds(dieTime);

        if (enemyCtrl.EnemySpawner != null)
        {
            enemyCtrl.EnemySpawner.Despawn(transform);
            enemyCtrl.EnemyDamageReceiver.DropItemOnDead();

        }
        else
        {
            enemyRoot.gameObject.SetActive(false);
            enemyCtrl.EnemyDamageReceiver.DropItemOnDead();
        }
    }
}
