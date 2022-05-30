using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour , ISelectable
{
    private Vector3 originalSize;

    public Canvas UI;


    private void Start()
    {
        originalSize = transform.localScale;
    }

    public virtual void OnSelect(Player player)
    {
        
        UI.gameObject.SetActive(true);
        gameObject.transform.localScale = originalSize;
        
    }

    public virtual void OnHoverEnter(Player player)
    {
        gameObject.transform.localScale += new Vector3(0.3f, 0.3F, 0.3f);
    }

    public virtual void OnHoverExit(Player player)
    {
        gameObject.transform.localScale = originalSize;
    }

    public virtual void OnDeselect(Player player)
    {
        UI.gameObject.SetActive(false);
    }
}
