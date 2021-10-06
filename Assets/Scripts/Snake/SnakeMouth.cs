using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMouth : MonoBehaviour
{
    private float _ScaleY = 1f;
    private Vector3 _baseScale;

    private void Awake()
    {
        _baseScale = transform.localScale;
    }
    public void SetFewerMouth() {
        transform.localScale = new Vector3(transform.localScale.x, _ScaleY); 
    }

    public void SetNormalMouth() {
        transform.localScale = _baseScale;
    }
}
