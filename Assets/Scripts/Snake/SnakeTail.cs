using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailGeneration))]
public class SnakeTail : MonoBehaviour
{
    private int _tailCount = 3;
    private List<Segment> _tail;

    [SerializeField] private float _springless;
    private void Start()
    {
        _tail = GetComponent<TailGeneration>().Generate(_tailCount);
    }

    private void FixedUpdate()
    {
        MoveTail();
    }

    private void MoveTail()
    {
        Vector3 previousPoint = transform.position;
        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector3.Lerp(segment.transform.position, previousPoint, _springless * Time.fixedDeltaTime);
            previousPoint = tempPosition;
        }
    }
}