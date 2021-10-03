using System.Collections.Generic;
using UnityEngine;

public class TailGeneration : MonoBehaviour
{
    [SerializeField] private Segment _segmentTamplate;

    public List<Segment> Generate(int count)
    {
        List<Segment> tail = new List<Segment>();

        for (int i = 0; i < count; i++)
        {
            _segmentTamplate.GetComponent<Rigidbody>();
            tail.Add(Instantiate(_segmentTamplate, transform.position, Quaternion.identity, transform));
        }
        return tail;
    }
}