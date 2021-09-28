using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float speed;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(int newDirection)
    {
        _rigidbody.velocity =new Vector3(_rigidbody.velocity.x + newDirection*speed, _rigidbody.velocity.y, _rigidbody.velocity.z);
    }
}
