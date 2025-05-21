using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : TrisMonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] protected List<Transform> abilities;

    protected override void LoadComponents()
    {
        this.LoadAbility();
    }
    protected virtual void LoadAbility()
    {
        if (this.abilities.Count > 0) return;

        foreach (Transform child in transform)
        {
            this.abilities.Add(child);
        }
    }
}
