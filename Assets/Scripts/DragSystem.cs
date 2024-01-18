using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class DragSystem : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;
    private SpriteRenderer sprite;
    private Vector2 startPosirion;
    private bool isTouchingSomething = false;
    public Collider2D _whatIsTouching;
    private SpriteRenderer spriteRenderer;
    //private bool _isDeleting = false;

    private bool _isMoving = false;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosirion = transform.position;
    }

    private void OnEnable()
    {
        EditMode.onEdited += ChangeToEditMode;
    }
    private void OnDisable()
    {
        EditMode.onEdited -= ChangeToEditMode;
    }

    public void ChangeToEditMode(bool isEditing)
    {
        if (isEditing)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        gameObject.transform.parent = null;
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        _isMoving = true;
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        if (isTouchingSomething && _whatIsTouching != null)
        {
            if (gameObject.tag == "Decor" && _whatIsTouching.tag == "Furniture")
                sprite.color = new Color(1, 1, 1, 0.7f);
            else
                sprite.color = new Color(1, 0.5f, 0.5f, 0.7f);
        }
        else
            sprite.color = new Color(1, 1, 1, 0.7f);

    }
    private void OnMouseUp()
    {
        if(_whatIsTouching != null)
        {
            Debug.Log(_whatIsTouching.tag);
            switch (_whatIsTouching.tag)
            {
                case "Furniture":
                    {
                        if (gameObject.tag == "Decor")
                            gameObject.transform.SetParent(_whatIsTouching.transform, true);
                        else
                            transform.position = startPosirion;
                    }
                    break;
                case "Decor":
                    {
                        if (!(gameObject.tag == "Furniture" && gameObject.transform.childCount != 0))
                            transform.position = startPosirion;
                    }
                    break;
                case "Building":
                    {
                        transform.position = startPosirion;
                    }
                    break;
            }
            
        }
        sprite.color = new Color(1, 1, 1, 1);
        startPosirion = transform.position;
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100);

        _isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);

        if (_isMoving)
        {
            isTouchingSomething = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _whatIsTouching = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingSomething = false;
        _whatIsTouching = null;
        if (gameObject.transform.IsChildOf(collision.transform))
        {
            gameObject.transform.parent = null;
        }
    }

    /*
    private void ChangeDeletingStatus()
    {
        _isDeleting = !_isDeleting;
    }

    private void OnEnable()
    {
        DeleteObjects.onDeleted += ChangeDeletingStatus;
    }

    private void OnDisable()
    {
        DeleteObjects.onDeleted -= ChangeDeletingStatus;
    }

    private void DeleteObject()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            foreach (Transform child in hit.collider.gameObject.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(hit.collider.gameObject);
        }
    }
    */
}
