using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField] private float _speed;
    
    private Vector3 _directionX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        MovePositionX();
    }

    public void MovePositionX() 
    {
        Vector3 direction = (_directionX - _rigidbody.position);
        Vector3 lerpPosition = Vector3.Lerp(_rigidbody.position, direction * 6f, _speed * Time.fixedDeltaTime);
        Vector3 moveX = new Vector3(lerpPosition.x,_rigidbody.position.y, _rigidbody.position.z);
        _rigidbody.MovePosition(moveX);
    }

    public void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + Vector3.forward * _speed * Time.deltaTime);
    }

    public void ResetPosition()
    {
        _rigidbody.position = new Vector3(0f, _rigidbody.position.y, _rigidbody.position.z);
    }

    private void GetDirectionX(Vector3 directionX)
    {
        _directionX = directionX;
    }

    private void OnEnable()
    {
        SnakeInput.OnMove += GetDirectionX;
    }

    private void OnDisable()
    {
        SnakeInput.OnMove -= GetDirectionX;
    }
}
