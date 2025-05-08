using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : TrisMonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] public List<ItemInventory> items;


    protected override void Start()
    {
        AddItem(ItemCode.NormalBullet, 30);
    }
    public virtual int AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile<ItemProfileSO>(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        int addedTotal = 0;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if(this.IsInventoryFull())return 0;

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
                addedTotal += addMore;
            }
            else
            {
                addRemain -= newCount;
            }
            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return addedTotal;
    }

    //public virtual int DeductItem (ItemCode itemCode, int deductCount)
    //{
    //    ItemProfileSO itemProfile = this.GetItemProfile<ItemProfileSO>(itemCode);

    //    int deductRemain = deductCount;
    //    int deductMore;
    //    int deductedTotal = 0;
    //    ItemInventory itemExist;


    //    for (int i = this.items.Count - 1; i >= 0; i--)
    //    {
    //            itemExist = this.items[i];
    //        if (itemExist.itemProfile.itemCode == itemCode)
    //        {
    //            deductMore = Mathf.Min(deductRemain, itemExist.itemCount);

    //            itemExist.itemCount -= deductMore;
    //            deductRemain -= deductMore;
    //            deductedTotal += deductMore;

    //            if (itemExist.itemCount <= 0)
    //            {
    //                this.items.RemoveAt(i); 
    //            }

    //            if (deductRemain <= 0) break;
    //        }
    //    }
    //    return deductedTotal;
    //}
    public virtual int DeductItem(ItemProfileSO profile, int deductCount)
    {
        int deductRemain = deductCount;
        int deductedTotal = 0;

        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            var item = this.items[i];
            if (item.itemProfile == profile)
            {
                int deductMore = Mathf.Min(deductRemain, item.itemCount);
                item.itemCount -= deductMore;
                deductRemain -= deductMore;
                deductedTotal += deductMore;

                if (item.itemCount <= 0)
                    this.items.RemoveAt(i);

                if (deductRemain <= 0)
                    break;
            }
        }

        return deductedTotal;
    }
    public virtual int DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemProfileSO profile = this.GetItemProfile<ItemProfileSO>(itemCode);
        if (profile == null)
        {
            Debug.LogWarning($"Không tìm thấy profile với mã {itemCode}");
            return 0;
        }

        return DeductItem(profile, deductCount); // Gọi lại hàm phía trên
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

    //protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    //{
    //    var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));

    //    foreach (ItemProfileSO profile in profiles)
    //    {
    //        if (profile.itemCode != itemCode) continue;
    //        return profile;
    //    }
    //    return null;
    //}
    public virtual T GetItemProfile<T>(ItemCode itemCode) where T : ItemProfileSO
    {
        var profiles = Resources.LoadAll("Item", typeof(T));

        foreach (T profile in profiles)
        {
            if (profile.itemCode == itemCode)
                return profile;
        }
        return null;
    }

    protected virtual bool IsInventoryFull()
    {
        if(this.items.Count >=this.maxSlot) return true;
        return false;
    }

    public virtual int GetItemCount(ItemCode itemCode)
    {
        int itemCountInInventory = 0;
        foreach (var item in this.items)
        {
            if (item.itemProfile.itemCode == itemCode)
            {
                return itemCountInInventory += item.itemCount;
            }
        }
        return itemCountInInventory;
    }
}
    