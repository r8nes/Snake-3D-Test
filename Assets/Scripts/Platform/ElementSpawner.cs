using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    private float _offsetZ = 10f;
    private float _offsetX = 0.2f;
    private float _rightPosition = 1.5f;
    private bool _isRight = true;

    private List<Vector3> _positionList = new List<Vector3>();

    [SerializeField] private int _count;
    [SerializeField] public FoodGenerator _foodGeneratorTamoplate;

    private void Start()
    {
        SpawnElementsOnPlatform();
    }

    private void SpawnElementsOnPlatform()
    {
        for (int i = 0; i < _count; i++)
        {
            Vector3 random = Vector3.zero;

            if (_isRight == false)
            {
                _rightPosition = -_rightPosition;
            }
            else
            {
                _isRight = !_isRight;
            }

            random.x = Random.Range(_rightPosition + _offsetX, _rightPosition + -_offsetX);
            random.z = Random.Range(-transform.localScale.z / 2 + _offsetZ, transform.localScale.z / 2);

            _positionList.Add(random);
            bool isExist = CheckExitstPosition();
            if (isExist)
            {
                random.z = transform.localScale.z + 5f;
            }
            RepeatCount(3, random.x, random.z);
        }
    }

    private void RepeatCount(int repeatCount, float x, float z)
    {
        float offsetZ = 5f;

        for (int i = 0; i < repeatCount; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(x, transform.localPosition.y + transform.localScale.y / 2, z + offsetZ);
            Instantiate(_foodGeneratorTamoplate, randomPosition, Quaternion.identity);
            offsetZ += 4f;
        }
    }

    private bool CheckExitstPosition()
    {
        for (int i = 0; i < _positionList.Count; i++)
        {
            int j = -5;
            while (j < 5)
            {
                Vector3 currentPosition = _positionList[i];
                if (currentPosition.z == (currentPosition.z + j))
                {
                    return false;
                }
                j++;
            }
        }
        return true;
    }
}
