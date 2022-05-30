using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Location
{
    Limbo,
    Hell,
    Earth
}
public static class PlayerStatus
{
   
    
    public static event Action<Location> OnPlayerChangeLocation;

    public static void CallOnPlayerChanceLocation(Location location)
    {
        OnPlayerChangeLocation?.Invoke(location);
    }

}
public class PortalPad : MonoBehaviour , ISelectable
{
    public GameObject portalObject;
    public GenericItem portalItem;
    public GenericItem fluidItem;
    public Location Location;

    public PortalPad teleportTo;
    public Transform placeZone;

    public bool hasPortal;



    private Vector3 iniSizi;

    private void Awake()
    {
        iniSizi = transform.localScale;
    }

    private void Start()
    {
        if (hasPortal)
        {
            portalObject.gameObject.SetActive(true);
        }
    }

    public void TeleportToPad(Player p, PortalPad pad)
    {
        p.transform.position = pad.placeZone.position;
        
        p.Location = pad.Location;
        PlayerStatus.CallOnPlayerChanceLocation(p.Location);
    }
    
    public void OnSelect(Player player)
    {
        transform.localScale = iniSizi; 

        if (hasPortal)
        {
            TeleportToPad(player,teleportTo);
            
            return;
        }
        
        if (player.Inventory.HasItemAndQuantity(portalItem, 1) && player.Inventory.HasItemAndQuantity(fluidItem, 1))
        {
            portalObject.gameObject.SetActive(true);
            player.Inventory.RemoveItem(portalItem,1);
            player.Inventory.RemoveItem(fluidItem,1);
            hasPortal = true;
        }
    }

    public void OnHoverEnter(Player player)
    {
        transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
    }

    public void OnHoverExit(Player player)
    {
        transform.localScale = iniSizi;
    }

    public void OnDeselect(Player player)
    {
    }
}
