using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : TrisMonoBehaviour
{
    [Header("Bullet Fly")]
    [SerializeField] protected float speedBullet = 40f;
    [SerializeField] protected Vector2 directionBullet = Vector2.right;
    [SerializeField] protected Rigidbody2D rb2;
    [SerializeField] protected Transform player;
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;
    protected virtual void FixedUpdate()
    {
        this.Fly();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadBulletCtrl();
        this.LoadPlayer();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb2 != null) return;
        rb2 = GetComponentInParent<Rigidbody2D>();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        bulletCtrl = GetComponentInParent<BulletCtrl>();
    }
    protected virtual void LoadPlayer()
    {
        if(player != null) return;
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        player = _player.transform;
    }
    protected virtual void Fly()
    {
        SetSpeedBullet();
        rb2.velocity = speedBullet * directionBullet;

        float angle = Mathf.Atan2(directionBullet.y, directionBullet.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public virtual void SetDirectionFly(Vector2 newDirection)
    {
        directionBullet = newDirection; 
    }

    public virtual void SetSpeedBullet()
    {
        this.speedBullet = bulletCtrl.WeaponProfile.ammoProfile.speedBullet;
    }
}
