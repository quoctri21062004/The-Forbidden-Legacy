using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupable : TrisMonoBehaviour
{
    [Header("Item Pickupable")]
    [SerializeField] protected CircleCollider2D circleCollider2D;
    [SerializeField] protected ItemCtrl itemCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadItemCtrl();

    }

    protected virtual void LoadSphereCollider()
    {
        if (circleCollider2D != null) return;
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    protected virtual void LoadItemCtrl()
    {
        if (itemCtrl != null) return;
        itemCtrl = transform.parent.GetComponent<ItemCtrl>();
    }

    protected static ItemCode StringToItemCode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }

    public virtual ItemCode GetItemCode()
    {
        try
        {
            return ItemPickupable.StringToItemCode(transform.parent.name);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
        
       
    }
    public virtual void Picked()
    {
        itemCtrl.ItemDespawn.DespawnObject();
    }
}
