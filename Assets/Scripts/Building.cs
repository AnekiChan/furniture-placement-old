using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Collider2D _mainCollider;
    [SerializeField] private Collider2D _floorCollider;
    [SerializeField] private Collider2D _leftWallCollider;
    [SerializeField] private Collider2D _rightWallCollider;
    public void StartBuildingEditMode()
    {
        _mainCollider.enabled = false;
        _floorCollider.enabled = true;
        _leftWallCollider.enabled = true;
        _rightWallCollider.enabled = true;
    }

    public void EndBuildingEditMode()
    {
        _mainCollider.enabled = true;
        _floorCollider.enabled = false;
        _leftWallCollider.enabled = false;
        _rightWallCollider.enabled = false;
    }
}
