using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideTilemap : MonoBehaviour
{
    private TilemapRenderer m_Renderer;

    void Start()
    {
        m_Renderer = GetComponent<TilemapRenderer>();
        m_Renderer.enabled = false;
    } 
}
