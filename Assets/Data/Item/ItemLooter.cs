using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLooter : InventoryAbstract
{
    [Header("Item Looter")]
    [SerializeField] protected CapsuleCollider2D capsuleCollider2D;
    [SerializeField] protected Rigidbody2D rid2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollieder();
        this.LoadRigidbody();
    }
    protected virtual void LoadCapsuleCollieder()
    {
        if(this.capsuleCollider2D != null)return;
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    protected virtual void LoadRigidbody()
    {
        if(this.rid2D != null) return;
        rid2D =transform.parent.parent.GetComponent<Rigidbody2D>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.GetItemCode();
        this.inventory.AddItem(itemCode, 1);
        itemPickupable.Picked();
        }
    }
