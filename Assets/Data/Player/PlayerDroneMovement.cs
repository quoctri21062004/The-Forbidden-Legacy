using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDroneMovement : TrisMonoBehaviour
{
    [Header("PlayerDrone Movement")]
    [SerializeField] protected Transform dronePrefab;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float limitDistance = 5f;

    protected virtual void FixedUpdate()
    {
        this.PlayerDroneFollowPlayer();
    }

    protected virtual void PlayerDroneFollowPlayer()
    {
        Vector2 targetPos = (Vector2)transform.parent.parent.position + new Vector2 (limitDistance,limitDistance);
        transform.parent.position = Vector2.Lerp(transform.position, targetPos, speed * Time.fixedDeltaTime);
    }
}
