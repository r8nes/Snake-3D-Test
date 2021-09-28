using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private int _sensevity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.forward * 0.1f, ForceMode.Impulse);
    }

    public void ChangeDirectionX(int xTouchInfo)
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x + xTouchInfo* _sensevity, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }

    public void ResetPosition()
    {
        _rigidbody.position = new Vector3(0f, _rigidbody.position.y, _rigidbody.position.z);
    }
}
