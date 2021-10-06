using UnityEngine;
using UnityEngine.UI;

public class SnakeSizeUpdate : MonoBehaviour
{
    [SerializeField] private Text _sizeView;
    [SerializeField] SnakeHead _snake;

    private void Start()
    {
        _snake = GetComponent<SnakeHead>();
    }

    private void OnSizeUpdated(int size) {
        _sizeView.text = size.ToString();
    }

    private void OnEnable()
    {
        _snake.SizeUpdated += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _snake.SizeUpdated -= OnSizeUpdated;
    }
}
