using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCode
{
    NoItem = 0,

    Heath = 1,

    NormalBullet = 2,
    ExplosiveBullet = 3,
    SplitBullet=4,

    Pistol=5,
}
public class ItemCodeParser
{
    public static ItemCode FromString(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;

        }
    }
}
