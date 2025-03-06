using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DameReceiver
{
    protected override void OnDead()
    {
        Debug.Log("Player da chet ");
    }
}
