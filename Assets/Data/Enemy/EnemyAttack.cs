using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : TrisMonoBehaviour
{
    [Header("Enemy Attack")]
    [SerializeField] protected MushroomAnimation mushroomAnimation;
    [SerializeField] protected Transform model;
    [SerializeField] protected float attackRange = 3f;
    [SerializeField] protected float attackTimeDelay = 1f;
    [SerializeField] protected float attackTimeLimit = 0f;

    protected virtual void Update()
    {
        this.Attack();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.parent.Find("Model");
    }
    protected virtual bool CheckDelay()
    {
        attackTimeLimit += Time.deltaTime;
        if (attackTimeLimit < attackTimeDelay) return false;
        attackTimeLimit = 0f;
        return true;
    }

    protected virtual bool CheckRaycastHit()
    {
        Vector2 directionAttack =Vector2.left;
        bool direction = model.localScale.x > 0 ? true : false;
        if (!direction)
        {
            directionAttack = Vector2.right;
        }

        int playerLayer = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionAttack, attackRange,playerLayer);

        Debug.DrawRay(transform.position, directionAttack * attackRange, Color.red);

        if (hit.collider == PlayerCtrl.Instance.PlayerRaycastReceiver.Collider2)
        {
            return true;
        }
        return false;
    }

    public virtual bool CanAttack()
    {
       if(!CheckDelay()) return false;
       if(!CheckRaycastHit()) return false;   
       return true;
    }
    protected virtual void Attack()
    {
        if (!CanAttack()) return;
       
        mushroomAnimation.MushroomAttackAnim();
    }


}
