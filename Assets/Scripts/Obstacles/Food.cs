using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
   [SerializeField] private int _bonusSize;

    public int Collect()
    {
        Destroy(gameObject);
        return _bonusSize;
    }
}