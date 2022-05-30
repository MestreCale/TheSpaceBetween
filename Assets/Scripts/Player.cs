using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *
 *   UP
 *   RIGHT
 *    DOWN
 *  LEFT
 * 
 */
public enum Facing
{
    
    Up,
    Right,
    Down,
    Left
}

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Facing _facing;

    public bool canMove;

    public Inventory Inventory;

    private ISelectable currentSelecting;

    private Rigidbody2D _rigidbody2D;

 

    public Sprite[] sprites;

    [Header("Dependencies")]
    public SpriteRenderer renderer;
  
    public PlayerData playerData;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public List<GenericItem> debugtoadd;

    public Location Location;

    private void Start()
    {
        Location = Location.Limbo;
        PlayerStatus.CallOnPlayerChanceLocation(Location);
        foreach (var genericItem in debugtoadd)
        {
            
            Inventory.AddItem(genericItem,100);
        }

        canMove = true;
    }

    private float updateTime;
    void Update()

    {

        if(!canMove) return;
        
        _rigidbody2D.velocity = Vector2.zero;
       
        
        if(Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        
       else if(Input.GetKey(KeyCode.S))
        {
            MoveDown();
            
        }
        
       else if(Input.GetKey(KeyCode.D))
        {
            MoveRight();
            
        }
        
       else  if(Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        
        updateTime += Time.deltaTime;
        if (updateTime >= 0.05f)
        {
            UpdateSelectableCheck();
            updateTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentSelecting != null)
            {
                currentSelecting.OnSelect(this);
                currentSelecting = null;
            }
        }


    
    
    }

    private void UpdateSelectableCheck()
    {
        Vector2 raycastDirection = Vector2.zero;
        Vector2 playerPosition = transform.position;
        Vector2 sizeOfRaycast = new Vector2(0.85f, 0.85f);
        
        switch (_facing)
        {
            case Facing.Up:
                raycastDirection = Vector2.up;;
                break;
            case Facing.Right:
                raycastDirection = Vector2.right;;
                break;
            case Facing.Down:
                raycastDirection = Vector2.down;;
                break;
            case Facing.Left:
                raycastDirection = Vector2.left;;
                break;
            
        }

   CheckForSelectableWithRaycast(playerPosition, sizeOfRaycast, raycastDirection);
   
   
    }

    public LayerMask toIgnore;
    private void CheckForSelectableWithRaycast(Vector2 playerPosition, Vector2 sizeOfRaycast, Vector2 raycastDirection)
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerPosition, sizeOfRaycast, 0, raycastDirection, 1.5f,~toIgnore);


        // Did we hit something?
        if (raycastHit2D.collider != null)
        {
            Debug.Log(raycastHit2D.collider.name);
            // Is what we  hit a ISelectable?
            ISelectable selectable = raycastHit2D.collider.GetComponent<ISelectable>();


            if (selectable != null && currentSelecting != selectable)
            {
                if (currentSelecting != null)
                {
                    currentSelecting.OnHoverExit(this);
                  
                        currentSelecting.OnDeselect(this);
            
                }

                currentSelecting = selectable;
                selectable.OnHoverEnter(this);
            }
        }
        else
        {
            if (currentSelecting != null)
            {
                currentSelecting.OnHoverExit(this);
            
                    currentSelecting.OnDeselect(this);
            
               
                currentSelecting = null;
            }
        }

    }

    private void UpdateSpriteLook()
    {
        renderer.sprite = sprites[(int) _facing];
    }
    
    private void MoveRight()
    {
      
        _facing = Facing.Right;
        
        Vector2 currentVelocity = _rigidbody2D.velocity;
        _rigidbody2D.velocity = new Vector2(playerData.Speed, currentVelocity.y);
        UpdateSpriteLook();
    }

  
    private void MoveLeft()
    {
        _facing = Facing.Left;
        Vector2 currentVelocity = _rigidbody2D.velocity;
        _rigidbody2D.velocity = new Vector2(-playerData.Speed, currentVelocity.y);
        UpdateSpriteLook();
    }

    private void MoveUp()
    {
        _facing = Facing.Up;
        Vector2 currentVelocity = _rigidbody2D.velocity;
        _rigidbody2D.velocity = new Vector2(currentVelocity.x, playerData.Speed);
        UpdateSpriteLook();
    }
    private void MoveDown()
    {
        
        _facing = Facing.Down;
        Vector2 currentVelocity = _rigidbody2D.velocity;
        _rigidbody2D.velocity = new Vector2(currentVelocity.x, -playerData.Speed);
        UpdateSpriteLook();
    }
}
