using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyAbstract
{
    [Header("Enemy Attack")]
    [SerializeField] protected Transform model;
    [SerializeField] protected float attackRange = 4f;
    [SerializeField] protected bool hasDetectedPlayer = false;

    public virtual bool CheckRaycastHit()
    {
        Vector2 directionAttack = Vector2.left;
        bool direction = model.localScale.x > 0 ? true : false;
        if (!direction)
        {
            directionAttack = Vector2.right;
        }

        int playerLayer = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionAttack, attackRange, playerLayer);

        Debug.DrawRay(transform.position, directionAttack * attackRange, Color.red);

        if (hit.collider == PlayerCtrl.Instance.PlayerRaycastReceiver.Collider2)
        {
            return true;
        }
        return false;
    }

    public virtual bool CanAttack()
    {
        if (!CheckRaycastHit()) return false;
        return true;
    }
    public void ResetDetection()
    {
        hasDetectedPlayer = false;
    }

}
