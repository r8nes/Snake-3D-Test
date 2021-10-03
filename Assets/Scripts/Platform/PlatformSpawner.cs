using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    [SerializeField] private Transform _generationPoint;
    
    private float _platformLength;  

    private void Awake()
    {
        _platformLength = _platform.transform.localScale.z;
    }

    private void Update()
    {
        if (transform.position.z < _generationPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _platformLength); 
            Instantiate(_platform, transform.position, Quaternion.identity, transform.parent);
        }
    }
}
