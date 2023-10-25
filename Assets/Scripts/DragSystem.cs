using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragSystem : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;
    private SpriteRenderer sprite;
    private Vector2 startPosirion;
    private bool isTouchingSomething = false;
    private SpriteRenderer spriteRenderer;
    private bool _isDeleting = false;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosirion = transform.position;
    }

    private void OnMouseDown()
    {
        if (!_isDeleting)
            difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        else
        {
            DeleteObject();
        }
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;

        if (isTouchingSomething)
            sprite.color = new Color(1, 0.5f, 0.5f, 0.7f);
        else
            sprite.color = new Color(1, 1, 1, 0.7f);
    }
    private void OnMouseUp()
    {
        if(isTouchingSomething == true)
        {
            transform.position = startPosirion;
        }
        sprite.color = new Color(1, 1, 1, 1);
        startPosirion = transform.position;
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Decor" && collision.tag == "Furniture" && gameObject.transform.parent == null)
        {
            //isTouchingSomething = false;
            gameObject.transform.SetParent(collision.transform, false);
        }
        else if (gameObject.tag == "Furniture" && collision.tag == "Decor")
        {
            isTouchingSomething = false;
        }
        else
            isTouchingSomething = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingSomething = false;
        if (gameObject.transform.IsChildOf(collision.transform))
        {
            gameObject.transform.parent = null;
        }
    }

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
}
