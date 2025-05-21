using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SummonAlly : AbilitiesBase
{
    // [Header("SummonAlly")]

    [SerializeField] protected SoulFireTrigger soulFireTrigger;
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected virtual void Update()
    {
        TrySummon();
    }
 

    protected override void Ability()
    {
        if (!CanUseAbility()) return;
        Summon();
        this.ResetAbility();
    }
    protected virtual void Summon()
    {
        SetSoulFireInfo soulFireInfo = SoulFireManager.Instance.currentSoulFireInfo;
        if (soulFireInfo == null)
        {
            Debug.LogWarning("Không có SoulFire nào đang tồn tại hoặc chưa được gán!");
            return;
        }

        EnemyType enemyType = soulFireInfo.GetEnemyType();

        Vector3 spawnPos = transform.position + Vector3.right * 1.5f;

        GameObject ally = AllySpawner.Instance.SpawnAlly(enemyType, spawnPos);

        if (ally != null)
        {
            Debug.Log($"Triệu hồi đồng minh từ {enemyType}");
        }
        else
        {
            Debug.LogWarning("Triệu hồi thất bại: Không tìm thấy prefab phù hợp.");
        }
    }
    protected virtual void TrySummon()
    {
        if (!InputManager.Instance.GetAbilities()) return;
        Ability();
    }
}
