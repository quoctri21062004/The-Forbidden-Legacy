using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AmmoProfile", menuName = "SO/AmmoProfile")]

public class AmmoProfileSO : ScriptableObject
{
    public AmmoType ammoType=AmmoType.NoType;
    public string ammoName = "no-name";
    public float damageSender = 0f;
    public float speedBullet = 0f;
}
