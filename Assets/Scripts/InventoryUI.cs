using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;


    public TextMeshProUGUI allInventory;
    private void OnEnable()
    {UpdateUI();


    }

    public void UpdateUI()
    {
        string inventoryString = String.Empty;

        List<StackableItem> allItems = Inventory.GetAllItems();
        if (allItems.Count <= 0)
        {
            inventoryString = "Empty Inventory";
        }
        else
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                string localString = $"{allItems[i].Item.itemName} {allItems[i].Amount}x \n";
                inventoryString += localString;


            }
        }
      

        allInventory.text = inventoryString;
    }
    private void OnDisable()
    {
        
    }
}
