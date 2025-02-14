using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnAround : TrisMonoBehaviour
{
    [Header("Player TurnAround")]
    [SerializeField] protected bool isTurnLeft = true;

    protected virtual void Update()
    {
        this.TurnAround();
    }
    protected virtual void TurnAround()
    {
        Vector2 playerDirection = InputManager.Instance.Direction;

        if(isTurnLeft && playerDirection.x!=0 || !isTurnLeft && playerDirection.y!=0)
        {
            isTurnLeft = !isTurnLeft;
            Vector3 scale = transform.parent.localScale;
            scale.x *= -1;
            transform.parent.localScale = scale;    
        }
    }

}
