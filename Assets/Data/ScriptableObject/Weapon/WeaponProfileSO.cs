using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponProfile", menuName = "SO/WeaponProfile")]

public class WeaponProfileSO : ScriptableObject
{
    public WeaponType weaponType = WeaponType.NoType;
    public string itemName = "no-name";
    public float damageSender = 0f;
    public float speedBullet = 0f;
}
