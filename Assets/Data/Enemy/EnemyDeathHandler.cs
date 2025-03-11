using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : TrisMonoBehaviour
{
    [Header("Enemy Death Handler")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected EnemyStateMachine enemyStateMachine;
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected Transform enemyRoot;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadEnemyStateMachine();
        this.LoadEnemySpawner();
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
        GameObject stateMachine = GameObject.Find("EnemyStateMachine");
        enemyStateMachine = stateMachine.GetComponent<EnemyStateMachine>();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (enemySpawner != null) return;
        enemySpawner = EnemySpawner.Instance;
    }


    public void HandleDeath()
    {
        float dieTime = GetDieAnimationLength();
        StartCoroutine(WaitForDeath(dieTime));
    }

    private float GetDieAnimationLength()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name.Contains("MushroomDie"))
                return clip.length;
        }
        return 1f;
    }

    private IEnumerator WaitForDeath(float dieTime)
    {
        yield return new WaitForSeconds(dieTime);

        if (enemySpawner != null)
        {
            Debug.Log("🛠 Despawn bằng EnemySpawner");
            enemySpawner.Despawn(transform);
        }
        else
        {
            Debug.Log("❌ Không có EnemySpawner, setActive false");
            enemyRoot.gameObject.SetActive(false);
        }
    }
}
