using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private bool _isFewer;

    private const float SPEED_MULIPLY = 3f;
    private float _lerpStabilization = 6f;

    private Rigidbody _rigidbody;
    private SnakeMouth _snakeMouth;
    private DiamondScore _diamondScore;
    private Vector3 _directionX;

    [SerializeField] private float _speed;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _snakeMouth = GetComponentInChildren<SnakeMouth>();
    }

    private void Start()
    {
        _diamondScore = GameObject.FindObjectOfType(typeof(DiamondScore)) as DiamondScore;
    }

    private void Update()
    {
        _isFewer = _diamondScore.IsScoreEquals();
    }

    private void FixedUpdate()
    {
        if (_isFewer == true)
        {
            _snakeMouth.SetFewerMouth();
            Move(SPEED_MULIPLY * _speed);
            ResetPosition(); 
        }
        else if (_isFewer == false)
        {
            _snakeMouth.SetNormalMouth();
            Move(_speed);
            MovePositionX();
        }
    }

    private void MovePositionX()
    {
        Vector3 direction = (_directionX - _rigidbody.position);
        Vector3 lerpPosition = Vector3.Lerp(_rigidbody.position, direction * _lerpStabilization, _speed * Time.fixedDeltaTime);
        Vector3 moveX = new Vector3(lerpPosition.x, _rigidbody.position.y, _rigidbody.position.z);
        _rigidbody.MovePosition(moveX);
    }

    private void Move(float speed)
    {
        _rigidbody.MovePosition(_rigidbody.position + Vector3.forward * speed * Time.deltaTime);
    }

    private void ResetPosition()
    {
        _rigidbody.position = new Vector3(0f, _rigidbody.position.y, _rigidbody.position.z);
    }

    public bool GetFewerState()
    {
        return _isFewer;
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
