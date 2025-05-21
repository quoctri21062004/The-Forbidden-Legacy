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

        enemyCtrl.EnemyDamageReceiver.DropItemOnDead();

        Transform soulFire = FXSpawner.Instance.Spawn(FXSpawner.fxOne, transform.position, transform.rotation);
        FXSpawner.Instance.FXCtrl.SoulFireAnimation.FXRun();

        SetSoulFireInfo soulFireInfo = soulFire.GetComponentInChildren<SetSoulFireInfo>();
        if (soulFireInfo != null)
        {
            soulFireInfo.SetEnemyType(enemyStateMachine.EnemyProfileSO.enemyType);
            Debug.Log("Gán SoulFire với enemyType: " + soulFireInfo.enemyType);

            SoulFireManager.Instance.currentSoulFireInfo = soulFireInfo;
        }

        if (enemyCtrl.EnemySpawner != null)
        {
            enemyCtrl.EnemySpawner.Despawn(transform);
        }
        else
        {
            enemyRoot.gameObject.SetActive(false);
        }
    }
}
