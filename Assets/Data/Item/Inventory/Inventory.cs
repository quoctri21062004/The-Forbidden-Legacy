using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : TrisMonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if(this.IsInventoryFull())return false;

                itemExist = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain;
            itemMaxStack = GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }
            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory item in items)
        {
            if (itemCode != item.itemProfile.itemCode) continue;
            if (this.IsFullStack(item)) continue;

            return item;
        }
        return null;
    }
    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }
    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory();
        {
            itemInventory.itemProfile = itemProfile;
            itemInventory.maxStack = itemProfile.defaultMaxStack;
        }
        return itemInventory;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));

        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual bool IsInventoryFull()
    {
        if(this.items.Count >=this.maxSlot) return true;
        return false;
    }
}







        //public virtual bool AddItem(ItemCode itemCode, int addCount)
        //{
        //    ItemInventory itemInventory = this.GetItemByCode(itemCode);

        //    int newCount = itemInventory.itemCount + addCount;
        //    if (newCount > itemInventory.maxStack) return false; 

        //    itemInventory.itemCount = newCount;
        //    return true;
        //}

        //public virtual bool DeductItem(ItemCode itemCode,int deduct)
        //{
        //    ItemInventory itemInventory = this.GetItemByCode(itemCode);

        //    int newCount = itemInventory.itemCount - deduct;
        //    if(newCount < 0)return false;

        //    itemInventory.itemCount = newCount;
        //    return true;
        //}

        //public virtual ItemInventory GetItemByCode(ItemCode itemCode)
        //{
        //    ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        //    if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        //    return itemInventory;
        //}

        //protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
        //{
        //    var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));

        //    foreach (ItemProfileSO profile in profiles)
        //    {
        //        if (profile.itemCode != itemCode) continue;
        //        ItemInventory itemInventory = new ItemInventory
        //        {
        //            itemProfile = profile,
        //            maxStack = profile.defaultMaxStack
        //        };
        //        this.items.Add(itemInventory);
        //        return itemInventory;
        //    }
        //    return null;
        //}
    