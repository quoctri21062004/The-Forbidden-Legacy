using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFireManager : TrisMonoBehaviour
{
    [Header("SoulFireManager")]

    private static SoulFireManager instance;
    public static SoulFireManager Instance => instance;

    public SetSoulFireInfo currentSoulFireInfo;

    protected override void Awake()
    {
        base.Awake();
        if (SoulFireManager.instance != null) Debug.LogError("Only 1 SoulFireManager allow to exist");
        SoulFireManager.instance = this;
    }

}
