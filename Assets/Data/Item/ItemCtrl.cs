using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : TrisMonoBehaviour
{
    [Header("Item Ctrl")]
    [SerializeField]protected ItemPickupable itemPickupable;
    public ItemPickupable ItemPickupable => itemPickupable;

    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemPickupablle();
        this.LoadItemDespawn();
    }
    protected virtual void LoadItemPickupablle()
    {
        if(itemPickupable!=null) return;
        itemPickupable = GetComponentInChildren<ItemPickupable>();
    }
    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) return;
        itemDespawn = GetComponentInChildren<ItemDespawn>();
    }


}
