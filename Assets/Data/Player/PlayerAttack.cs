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
        if (!InputManager.Instance.GetSignalsByMouse()) return false;
        return true;
    }
    protected virtual void Attack()
    {
        if (!IsAttack()) return ;
        if (!AmmoManager.Instance.CheckHasAmmo())
        {
            Debug.Log("Het dan roi.Dung ban nua");
            return;
        }
        //this.timer += Time.fixedDeltaTime;
        //if (this.timer < delayTime) return;
        //this.timer = 0f;
        Vector3 mousePos = InputManager.Instance.GetMousePos();
        
        Vector2 gunPos = WeaponCtrl.Instance.Model.transform.position;

        Vector2 direction = (mousePos - (Vector3)gunPos).normalized;
        Transform newBullet =BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,gunPos, Quaternion.identity);
        AmmoManager.Instance.UseAmmo();

        BulletFly bulletFly = newBullet.GetComponentInChildren<BulletFly>();
        //if (bulletFly == null)
        //{
        //    Debug.LogError("BulletFly = null");
        //    return;
        //}
       // Vector2 direction = (gunPos - (Vector2)newBullet.position).normalized;
        bulletFly.SetDirectionFly(direction);
    }
   
}
