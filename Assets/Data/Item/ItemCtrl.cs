using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCtrl : TrisMonoBehaviour
{
    [Header("Item Ctrl")]
    [SerializeField] protected ItemPickupable itemPickupable;
    public ItemPickupable ItemPickupable => itemPickupable;

    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemPickupablle();
        this.LoadItemDespawn();
        this.LoadInventory();
    }
    protected virtual void LoadItemPickupablle()
    {
        if (itemPickupable != null) return;
        itemPickupable = GetComponentInChildren<ItemPickupable>();
    }
    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) return;
        itemDespawn = GetComponentInChildren<ItemDespawn>();
    }
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
    }
    protected virtual void LoadInventory()
    {
        if (itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.ResetItem();

    }
    protected virtual void ResetItem()
    {
        this.ItemInventory.itemCount = 1;
        this.ItemInventory.upgradeLevel = 0;
    }

}
