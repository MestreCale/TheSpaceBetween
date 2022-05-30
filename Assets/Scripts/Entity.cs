using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, ISelectable
{

    public GenericItem limboessence;


    public Canvas HURRAYYOUFUCKINGWON;
    public void OnSelect(Player player)
    {
        if (player.Inventory.HasItemAndQuantity(limboessence, 1))
        {
            player.Inventory.RemoveItem(limboessence,1);
            
            HURRAYYOUFUCKINGWON.gameObject.SetActive(true);
            player.canMove = false;
            player.Location = Location.Earth;
            PlayerStatus.CallOnPlayerChanceLocation(player.Location);
        }
        

    }

    public void OnHoverEnter(Player player)
    {
    }

    public void OnHoverExit(Player player)
    {
    }

    public void OnDeselect(Player player)
    {
    }
}
