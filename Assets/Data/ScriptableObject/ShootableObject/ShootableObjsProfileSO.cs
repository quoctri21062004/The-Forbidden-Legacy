using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject",menuName =("SO/ShootableObjsProfile"))]
public class ShootableObjsProfileSO : ScriptableObject
{
    [Header("ShootableObjs ProfileSO")]
    public string ObjName = "Shootable Object";
    public ShootableObjsType objType;
    public int hpMax = 2;
    public List<ItemDropRate> dropList;
}
