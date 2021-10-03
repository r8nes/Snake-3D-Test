using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IInteractable
{
   [SerializeField] private int _bonusSize;

    public int Collect()
    {
        Destroy(gameObject);
        return _bonusSize;
    }
}