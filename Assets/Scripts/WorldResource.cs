using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISelectable
{
    public void OnSelect(Player player);
    public void OnHoverEnter(Player player);
    public void OnHoverExit(Player player);
    public void OnDeselect(Player player);
}

public class WorldResource : MonoBehaviour, ISelectable
{
    private Vector3 originalSize;

    public WorldItem itemOnDrOP;

    private SpriteRenderer _renderer;
    private BoxCollider2D _boxCollider2D;

    public AudioSource hitting;


    private void Awake()
    {
        hitting = GetComponent<AudioSource>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        originalSize = transform.localScale;
    }

    public void OnSelect(Player player)
    {
        if(itemOnDrOP == null) return;

        if (hitting != null)
        {
            hitting.Play();
        }
        Instantiate(itemOnDrOP, transform.position, Quaternion.identity);
        _renderer.enabled = false;
        _boxCollider2D.enabled = false;
        Destroy(gameObject,2f);
    }

  
    public void OnHoverEnter(Player player)
    {
        gameObject.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);

    }

    public void OnHoverExit(Player player)
    {
     
          gameObject.transform.localScale = originalSize;

    }

    public void OnDeselect(Player player)
    {
    
    }
}
