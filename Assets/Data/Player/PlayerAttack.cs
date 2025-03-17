using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : TrisMonoBehaviour
{
    [Header("Player Attack")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delayTime = 0f;
    protected virtual void Update()
    {
        this.Attack();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

  
    public virtual bool IsAttack()
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
        this.timer += Time.deltaTime;
        if (this.timer < delayTime) return;
        this.timer = 0f;

        Vector3 mousePos = InputManager.Instance.GetMousePos();
        
        Vector2 direction = (mousePos - PlayerCtrl.Instance.PlayerDrone.transform.position).normalized;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,PlayerCtrl.Instance.PlayerDrone.targetPoint.transform.position, Quaternion.identity);
        AmmoManager.Instance.UseAmmo();

        BulletFly bulletFly = newBullet.GetComponentInChildren<BulletFly>();
        bulletFly.SetDirectionFly(direction);
    }
   
}
