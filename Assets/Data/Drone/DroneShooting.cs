using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShooting : TrisMonoBehaviour
{
    [Header("Drone Shooting")]
    [SerializeField] protected Transform bullet;
    [SerializeField] protected Transform spawnPos;
    [SerializeField] protected float timeDelay = 2f;
    [SerializeField] protected float timer = 0f;

    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        this.timer += Time.fixedDeltaTime;
        if (timer < timeDelay) return;
        this.timer = 0f;

        if (!AmmoManager.Instance.CheckHasAmmo())
        {
            Debug.Log("Drone het dan roi.Vui long nap them dan!!");
            return;
        }
        Transform nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null) return;
        Vector2 direction = (nearestEnemy.position-transform.parent.position).normalized;

       
        Transform newBullet = BulletSpawner.Instance.Spawn(this.bullet,spawnPos.position, Quaternion.identity);
        AmmoManager.Instance.UseAmmo();

        BulletFly bulletFly = newBullet.GetComponentInChildren<BulletFly>();
        bulletFly.SetDirectionFly(direction);
    }

    protected virtual Transform FindNearestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 20f, LayerMask.GetMask("Enemy"));
        Transform nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            float distance = Vector2.Distance(transform.parent.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }
        return nearestEnemy;
    }
 
}
