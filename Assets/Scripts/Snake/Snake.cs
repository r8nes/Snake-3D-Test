using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private List<Segment> _tail;
    private TailGeneration _tailGeneration;

    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringness;
    [SerializeField] private int _tailSize;
    [SerializeField] private SnakeHead _head;

    private void Awake()
    {
        _tailGeneration = GetComponent<TailGeneration>();
        _tail = _tailGeneration.Generate(_tailSize);
    }

    private void GetDirectionX(int directionX)
    {
        Vector3 previousPoint = _head.transform.position;
        _head.Move(directionX);

        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previousPoint, _tailSpringness * Time.deltaTime);
            previousPoint = tempPosition;
        }
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
