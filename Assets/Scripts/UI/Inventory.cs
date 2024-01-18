using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<FurnitureScriptbleObject> InteriorFurnitures;
    [SerializeField] private List<FurnitureScriptbleObject> ExteriorFurnitures;
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _draggingParent;

    public void OnEnable()
    {
        Render(ExteriorFurnitures);
    }

    public void Render(List<FurnitureScriptbleObject> furnitures)
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }

        furnitures.ForEach(furniture =>
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            //cell.Init(_draggingParent);
            cell.Render(furniture);
        });
    }

    public void RenderInterior()
    {
        Render(InteriorFurnitures);
    }

    public void RenderExterior()
    {
        Render(ExteriorFurnitures);
    }

    private void OnMouseDown()
    {
        Debug.Log("click");
    }
}
