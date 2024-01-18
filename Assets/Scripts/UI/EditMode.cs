using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EditMode : MonoBehaviour
{
    public static Action<bool> onEdited;
    private bool _isEditing = false;
    [SerializeField] GameObject _editPanel;
    [SerializeField] UnityEvent onEditedBuilding;
    [SerializeField] UnityEvent onEditedEnvironment;
    [SerializeField] private Camera _camera;
    public void EditModeButtonClick()
    {
        if (_isEditing == false)
        {
            _isEditing = true;
            _editPanel.SetActive(true);
        }
        else
        {
            _isEditing = false;
            _editPanel.SetActive(false);
        }

        onEdited?.Invoke(_isEditing);
    }

    public void EditBuilding()
    {
        onEditedBuilding?.Invoke();
        _camera.GetComponent<CameraMovesToBuilding>().enabled = true;
    }

    public void EditEnvironment()
    {
        onEditedEnvironment?.Invoke();
    }
}
