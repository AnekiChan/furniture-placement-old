using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAndCloseInventory : MonoBehaviour
{
    private bool _isOpen = true;
    private float _yPos;
    [SerializeField] float difference = 1;
    [SerializeField] private Text _buttonText;

    private void Start()
    {
        _yPos = transform.position.y;
    }

    public void ButtonClick()
    {
        if (_isOpen)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - difference);
            _buttonText.text = "^";
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + difference);
            _buttonText.text = "v";
        }

        _isOpen = !_isOpen;
    }
}
