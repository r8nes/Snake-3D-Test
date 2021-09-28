using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    [SerializeField] private int _direction;

    public static event Action<int> OnMove;

    private void Update()
    {
        _direction = 0;

        if (Input.GetMouseButton(0))
        {
           Vector3 viewPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            _direction = viewPosition.x > 0.5 ? 1 : -1;
        }
            OnMove?.Invoke(_direction);
    }
}
