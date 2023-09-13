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

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        startPosirion = transform.position;
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
                transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        //transform.position = Vector2.MoveTowards(transform.position, ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference), 100 * Time.deltaTime);

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouchingSomething = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingSomething = false;
        //sprite.color = new Color(1, 1, 1, 1);
    }
}
