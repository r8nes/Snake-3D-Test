using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailGeneration))]
public class SnakeTail : MonoBehaviour
{
    private List<Segment> _tailList;
    private TailGeneration _tailGenerator;

    [SerializeField] private int _startTailCount;
    [SerializeField] private float _springless;
    private void Start()
    {
        _tailGenerator = GetComponent<TailGeneration>();
        _tailList = _tailGenerator.Generate(_startTailCount);
    }

    private void FixedUpdate()
    {
        MoveTail();
    }

    private void MoveTail()
    {
        Vector3 previousPoint = transform.position;

        foreach (var segment in _tailList)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector3.Lerp(segment.transform.position, previousPoint, _springless * Time.fixedDeltaTime);
            previousPoint = tempPosition;
        }
    }

    public int GetTailCount()
    {
        return _tailList.Count;
    }

    private void OnBonusCollected(int bonusSize)
    {
        _tailList.AddRange(_tailGenerator.Generate(bonusSize));
    }

    private void OnEnable()
    {
        SnakeHead.BonusCollected += OnBonusCollected;
    }

    private void OnDisable()
    {
        SnakeHead.BonusCollected += OnBonusCollected;
    }
}