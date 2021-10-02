using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    public static event Action<Vector3> OnMove;

    private void Update()
    {
#if UNITY_ANDROID
        GetTouchPosition();
#endif
    }
    private void GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out hit))
            {
                OnMove?.Invoke(hit.point);
            }
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.black);
        }
    }
}


