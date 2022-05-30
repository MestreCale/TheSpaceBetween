using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CraftHouse : House
{

    public Canvas craftingCanvas;


    public InventoryUI ievnefie;
    

    public Inventory Inventory;
    
    public Button[] Buttons;

    
    public void CraftRecipe(Recipe recipe)
    {
        bool hasEnoughOfEverything = true;

        List<GenericItem> itemsToCheck = recipe.needed;
        
        foreach (var genericItem in itemsToCheck)
        {
            if (Inventory.HasItemAndQuantity(genericItem, recipe.amountOfEach))
            {
                continue;
            }

            hasEnoughOfEverything = false;

        }

        if (hasEnoughOfEverything)
        {
        foreach (var genericItem in itemsToCheck)
        {
          
                Inventory.RemoveItem(genericItem,recipe.amountOfEach);
           
        }
        Inventory.AddItem(recipe.given,recipe.amountGiven);
        }

        ievnefie.UpdateUI();
        
       

    }



    public override void OnSelect(Player player)
    {
        base.OnSelect(player);
        craftingCanvas.gameObject.SetActive(true);
        
    }

    public override void OnDeselect(Player player)
    {
        base.OnDeselect(player);
        craftingCanvas.gameObject.SetActive(false);
    }
}
