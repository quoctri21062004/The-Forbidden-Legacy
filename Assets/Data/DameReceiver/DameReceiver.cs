using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DameReceiver : TrisMonoBehaviour
{
    [Header("DameReceiver")]
    [SerializeField] protected Collider2D collider2;
    [SerializeField] protected float currentHp = 1f;
    public float CurrentHp => currentHp;

    [SerializeField] protected float maxHp = 10f;
    public float MaxHp => maxHp;

    [SerializeField] protected bool isDead = false;

    protected override void Start()
    {
        base.Start();
        this.SetHP();
    }

    protected override void OnEnable()
    {
        this.SetHP();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetHP();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.collider2 != null) return;
        this.collider2 = GetComponent<Collider2D>();
    }


    public virtual void SetHP()
    {
        this.currentHp = maxHp;
        this.isDead = false;
    }
    public virtual void Add(float addHp)
    {
        if (this.isDead) return;

        this.currentHp += addHp;
        if (this.currentHp > maxHp) this.currentHp = maxHp;

    }
    public virtual void Deduct(float damage)
    {
        if (this.isDead) return;
        this.currentHp -= damage;
        if (this.currentHp < 0f) this.currentHp = 0f;
        this.CheckDead();
    }

    public virtual bool IsDead()
    {
        return this.currentHp <= 0;
    }
    protected virtual void CheckDead()
    {
        if (!IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected abstract void OnDead();

}
