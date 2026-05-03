using System;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;
    private Vector2 _offset;
    private Material _material;

    private void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        _offset += moveSpeed * Time.deltaTime;
        _material.mainTextureOffset = _offset;
    }
}
