using System;
using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    private SnakeTail _tail;

    public static UnityAction<int> BonusCollected;
    public event UnityAction<int> SizeUpdated;

    private void Awake()
    {
        _tail = GetComponent<SnakeTail>(); 
    }

    private void Update()
    {
        SizeUpdated?.Invoke(_tail.GetTailCount());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            BonusCollected?.Invoke(interactable.Collect());
            SizeUpdated?.Invoke(_tail.GetTailCount());
        }
    }
}
