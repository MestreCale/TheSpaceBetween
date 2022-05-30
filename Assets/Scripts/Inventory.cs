using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Inventory", fileName = "Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    private Dictionary<GenericItem, StackableItem> inventoryData = new Dictionary<GenericItem, StackableItem>();



    public bool HasItemAndQuantity(GenericItem item, int quantity)
    {
        bool has = inventoryData.TryGetValue(item, out StackableItem stackableItem);
        if (has)
        {
            return quantity <= stackableItem.Amount;
        }

        return false;
    }

    public List<StackableItem> GetAllItems()
    {
        List<StackableItem> allItems = new List<StackableItem>();
        var a = inventoryData.Values;
        
        foreach (var stackableItem in a)
        {
            allItems.Add(stackableItem);
        }

        return allItems;
    }

    public void AddItem(GenericItem item, int quantity)
    {
        Debug.Log("called");
        bool has = inventoryData.TryGetValue(item, out StackableItem stackableItem);
        if (has)
        {
            Debug.Log($"Added {quantity} to {item.name}");
            stackableItem.Amount += quantity;
        }
        else
        {
            Debug.Log($"Added {item.name}");
            inventoryData.Add(item,new StackableItem(item,quantity));
        }
        
    }

    public void RemoveItem(GenericItem item, int quantity)
    {
        bool has = inventoryData.TryGetValue(item, out StackableItem stackableItem);
        
        if (has)
        {
            if (stackableItem.Amount < quantity)
            {
                Debug.Log($"Not enough amount");
           
                return;
            }
            
            Debug.Log($"Removed {quantity} from {item.name}");
            stackableItem.Amount -= quantity;
          
            if (stackableItem.Amount <= 0)
            {
                Debug.Log($"Item is gone");
                inventoryData.Remove(item);
            }

        }

      
    }

}