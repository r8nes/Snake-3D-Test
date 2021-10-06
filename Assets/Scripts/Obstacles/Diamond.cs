using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private int _value = 1;

    public int Collect()
    {
        Destroy(gameObject);
        return _value;
    }
}