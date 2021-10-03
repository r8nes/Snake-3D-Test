using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUtility : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    public void ChangeColor(SnakeHead gameObject) 
    {
        int randomNumber= Random.Range(0, _materials.Length);
        MeshRenderer _objectMesh = gameObject.GetComponent<MeshRenderer>();
        _objectMesh.material = _materials[randomNumber]; 
    }
}
