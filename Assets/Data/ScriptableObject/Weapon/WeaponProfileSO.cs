using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponProfile", menuName = "SO/WeaponProfile")]

public class WeaponProfileSO : ItemProfileSO
{
    public WeaponType weaponType = WeaponType.NoType;
    public AmmoProfileSO ammoProfile = null;
    public string waeponName = "no-name";
}
