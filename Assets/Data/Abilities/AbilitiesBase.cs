using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilitiesBase : TrisMonoBehaviour
{
    [Header("AbilitiesBase")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float time = 12f;

    protected virtual bool AbilitiesDelay()
    {
        timer += Time.fixedDeltaTime;
        if(timer < time) return false;
        timer = 0f;
        return true;
    }

    protected abstract void Ability();
}
