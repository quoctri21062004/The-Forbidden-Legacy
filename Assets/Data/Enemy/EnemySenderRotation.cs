using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySenderRotation : EnemyAbstract
{
    [Header("Enemy Sender Rotation")]
    [SerializeField] protected Transform player;

    protected override void OnEnable()
    {
        this.UpdateEnemySenderPos();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        GameObject playerG = GameObject.Find("Player");
        this.player = playerG.transform;
    }

    protected virtual void UpdateEnemySenderPos()
    {
        Vector3 enemyPos = transform.parent.parent.position;
        Vector3 directionToPlayer = player.position - enemyPos;

        Vector3 newPos = transform.parent.localPosition;
        newPos.x = Mathf.Abs(newPos.x) * (directionToPlayer.x < 0 ? -1 : 1);

        transform.parent.localPosition = newPos;
        Debug.Log(transform.parent.name + " vị trí mới: " + transform.parent.localPosition);
    }
}
