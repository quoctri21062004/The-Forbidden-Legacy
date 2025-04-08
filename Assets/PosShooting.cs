using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosShooting : TrisMonoBehaviour
{
    protected virtual void UpdateEnemySenderPos()
    {
        Vector3 shootingPos = transform.position;
        Vector3 direction = transform.parent.position - shootingPos;

        Vector3 newPos = transform.localPosition;
        newPos.x = Mathf.Abs(newPos.x) * (direction.x < 0 ? -1 : 1);

        transform.localPosition = newPos;
    }
}
