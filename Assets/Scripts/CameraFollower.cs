using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _snake;

    private Vector3 _offset;
    private void Start()
    {
        _offset = transform.position -_snake.position;       
    }
    private void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, _snake.position.z + _offset.z);     
        transform.position = newPosition;
    }
}