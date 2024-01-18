using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EditMode : MonoBehaviour
{
    public static Action onEdit;
    private bool _isEditing = false;
    [SerializeField] GameObject _editPanel;

    private void Start()
    {
        
    }

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
    }
}
