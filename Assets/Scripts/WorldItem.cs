using System;
using System.Collections;

using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public GenericItem itemToGive;

    public AudioSource pickUPSound;
    public int quantityToGive;

    private float originalPosY;
    public float maxUp;
    public float maxValue => originalPosY + maxUp;


    private SpriteRenderer _spriteRenderer;
    private Collider2D colly;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        colly = GetComponentInChildren<Collider2D>();
    }

    private void Start()
    {
        originalPosY = transform.localScale.y;
        StartCoroutine(StartAnim());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player p0 = other.GetComponent<Player>();
        if (p0 != null)
        {
            if (pickUPSound != null)
            {
                pickUPSound.Play();
            }
            p0.Inventory.AddItem(itemToGive,quantityToGive);
            _spriteRenderer.enabled = false;
            colly.enabled = false;
            // Destroy(gameObject,2f);
        }
    }

    private IEnumerator StartAnim()
    {

        float n = 0;

        while (true)
        {
            yield return null;




        }
    }
    

}