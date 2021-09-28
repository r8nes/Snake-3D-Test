using System.Collections.Generic;
using UnityEngine;

public class SnakeCore : MonoBehaviour
{
    private int _touchInfo;

    private List<Segment> _tail;
    private TailGeneration _tailGeneration;

    [SerializeField] private float _tailSpringness;
    [SerializeField] private int _tailSize;
    [SerializeField] private SnakeMovement _snakeMovement;

    private void Start()
    {
        _tailGeneration = GetComponent<TailGeneration>();
        _tail = _tailGeneration.Generate(_tailSize);
    }

    private void FixedUpdate()
    {
        _snakeMovement.ChangeDirectionX(_touchInfo);
        MoveSegment();
    }

    private void MoveSegment()
    {
        Vector3 previousPoint = _snakeMovement.transform.position;
      
        foreach (Segment segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;

            segment.transform.position = Vector2.MoveTowards(segment.transform.position, previousPoint, _tailSpringness * Time.deltaTime);
            previousPoint = tempPosition;
        }
    }

    private void GetTouchInformation(int touchInfo)
    {
        _touchInfo = touchInfo;
    }

    private void OnEnable()
    {
        SnakeInput.OnMove += GetTouchInformation;
    }

    private void OnDisable()
    {
        SnakeInput.OnMove -= GetTouchInformation;
    }
}
