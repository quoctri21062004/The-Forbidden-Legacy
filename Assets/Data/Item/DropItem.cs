using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DropItem
{
    public ItemProfileSO itemSO;
    public float dropRate;
    public int minDrop;
    public int maxDrop;
}
