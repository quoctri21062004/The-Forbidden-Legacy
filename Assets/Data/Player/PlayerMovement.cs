using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : TrisMonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected Rigidbody2D rb2;

    protected virtual void Update()
    {
        this.Moving();
        this.UpdateTargetPos();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2();
    }
    protected virtual void LoadRigidbody2()
    {
        if (this.rb2 != null) return;
        rb2 = GetComponentInParent<Rigidbody2D>();
        Debug.LogWarning(transform.name + " :LoadRigidbody2", gameObject);
    }
    public virtual bool CheckIsMoving()
    {
        Vector2 playerDirection = InputManager.Instance.Direction;
        return playerDirection.sqrMagnitude > 0.01f;
    }
    protected virtual void Moving()
    {
        if (!this.CheckIsMoving())
        {
            rb2.velocity = Vector2.zero;
            return;
        }
        Vector2 moveDirection = InputManager.Instance.Direction;
        rb2.velocity = moveDirection*moveSpeed;
      //  transform.parent.Translate(moveDirection*moveSpeed * Time.fixedDeltaTime);

    }
    protected virtual void UpdateTargetPos()
    {
        Vector2 moveDirection = InputManager.Instance.Direction;

        if (moveDirection.sqrMagnitude > 0.01f) // Chỉ cập nhật khi Player di chuyển
        {
            PlayerCtrl.Instance.TargetPoint.position = (Vector2)transform.position + moveDirection.normalized * 10f;
        }
    }
}
