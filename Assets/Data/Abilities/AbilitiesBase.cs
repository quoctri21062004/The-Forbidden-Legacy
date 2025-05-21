using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilitiesBase : TrisMonoBehaviour
{
    [Header("AbilitiesBase")]
    [SerializeField] protected bool isUse = false;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float time = 12f;

    protected virtual void FixedUpdate()
    {
        AbilitiesDelay();
        CanUseAbility();
    }
    protected virtual bool AbilitiesDelay()
    {
        timer += Time.fixedDeltaTime;
        if(timer < time) return false;
        timer = 0f;
        this.isUse = true;
        return true;
    }

    protected virtual bool CanUseAbility()
    {
        if(!isUse)return false;
        return true;
    }
    protected virtual void ResetAbility()
    {
        this.isUse = false;
    }
    protected abstract void Ability();
}
