using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : TrisMonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] protected float moveSpeed = 2f;

    protected virtual void Update()
    {
        this.Moving();
    }
   
    protected virtual void Moving()
    {
        Vector4 direction = InputManager.Instance.Direction;
        Vector2 moveDirection = new Vector3(direction.x + direction.y, direction.z + direction.w).normalized;

        transform.parent.Translate(moveDirection*moveSpeed*Time.fixedDeltaTime);
    }
}
