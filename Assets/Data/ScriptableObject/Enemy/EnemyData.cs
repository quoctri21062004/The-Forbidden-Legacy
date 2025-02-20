using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy",menuName = "ScriptableObject/Enemy")]
public class EnemyData : ScriptableObject
{
    public string itemName;
    public float maxHp;
}
