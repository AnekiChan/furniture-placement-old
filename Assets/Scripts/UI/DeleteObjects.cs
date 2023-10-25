using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteObjects : MonoBehaviour
{
    public static Action onDeleted;
    private Image _buttonColor;
    private bool _isButtonPressed = false;
    [SerializeField] GameObject _inventory;

    private void Start()
    {
        _buttonColor = GetComponent<Image>();
    }
    public void DeleteButtunCkick()
    {
        if (_isButtonPressed)
        {
            _buttonColor.color = Color.white;
            _inventory.SetActive(true);
        }
        else
        {
            _buttonColor.color = Color.red;
            _inventory.SetActive(false);
        }
        _isButtonPressed = !_isButtonPressed;
        onDeleted?.Invoke();
    }
}
