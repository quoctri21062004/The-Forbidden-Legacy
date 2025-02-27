using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : TrisMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField]protected Inventory inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = transform.parent.GetComponent<Inventory>();
    }
}
