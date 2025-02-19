using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : TrisMonoBehaviour
{
    [Header("Player Attack")]

    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delayTime = 0f;

    protected virtual void Update()
    {
        this.Attack();
    }

    protected virtual bool IsAttack()
    {
        //timer += Time.deltaTime;
        //if (timer < delayTime) return false;
        //timer = 0f;
        //return true;
        if (!InputManager.Instance.GetSignalsByMouse()) return false;
        return true;

    }
    protected virtual void Attack()
    {
        if (!IsAttack()) return ;

        //this.timer += Time.fixedDeltaTime;
        //if (this.timer < delayTime) return;
        //this.timer = 0f;

        Vector2 targetPos = PlayerCtrl.Instance.TargetPoint.position;
        Transform newBullet =BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, PlayerCtrl.Instance.transform.position, Quaternion.identity);

        BulletFly bulletFly = newBullet.GetComponentInChildren<BulletFly>();
        if (bulletFly == null)
        {
            Debug.LogError("BulletFly = null");
            return;
        }
        Vector2 direction = (targetPos - (Vector2)newBullet.position).normalized;
        bulletFly.SetDirectionFly(direction);
    }
   
}
