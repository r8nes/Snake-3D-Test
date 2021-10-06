using System.Collections;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    private int _elementsSize;

    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private Vector2Int _elementsSizeRange;

    private void Start()
    {
        SpawnElement();
    }

    private void Update()
    {
        StartCoroutine("DestroyAfter");
    }

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);
    }


    private void SpawnElement()
    {

        _elementsSize = Random.Range(_elementsSizeRange.x, _elementsSizeRange.y);
        Vector3 random;

        ColorUtility.ColorVariant colorVariant = ColorUtility.GetRandomColor();

        for (int i = 0; i < _elementsSize; i++)
        {
            random.x = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            random.z = Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2);

            Vector3 randomPosition = transform.position + new Vector3(random.x, transform.localPosition.y + transform.localScale.y / 2, random.z);

            GameObject food = Instantiate(_foodPrefab, randomPosition, Quaternion.identity, transform);

            ColorUtility.ApplyColor(food, colorVariant);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x);
    }
}
