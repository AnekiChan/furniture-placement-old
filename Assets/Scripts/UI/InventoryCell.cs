using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image _iconField;
    public GameObject _furniturePref;

    //private Transform _draggingParent;
    //private Transform _originalParent;

    /*
    public void Init(Transform draggingParent)
    {
        _draggingParent = draggingParent;
        _originalParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _draggingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = (Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = _originalParent;
    }
    */
    public void Render(IFurniture furniture)
    {
        _iconField.sprite = furniture.UIIcon;
        _furniturePref = furniture.Pref;
    }
    
    public void OnButtonClick()
    {
        Vector2 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector2(.5f, .5f));
        rayOrigin.x += Random.Range(0f, 2f);
        rayOrigin.y += Random.Range(0f, 2f);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.tag != "Building")
        {
            Debug.Log("На экране нет места, передвиньте предметы");
        }
        else
        {
            Instantiate(_furniturePref, rayOrigin, Quaternion.identity);
        }
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Instantiate(_furniturePref, pos, Quaternion.identity);
    }
}
