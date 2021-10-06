using UnityEngine;
using UnityEngine.Events;

public class SnakeHead : MonoBehaviour
{
    private bool _isFewerActive;

    private SnakeTail _tail;
    private Material _headColor;

    public event UnityAction<int> SizeUpdated;
    public static UnityAction<int> SegmentCollected;
    public static UnityAction<int> DiamondCollected;
    public static UnityAction<Color> ColorUpdated;

    [SerializeField] private BoxCollider _fewerCollider;
    private void Awake()
    {
        _tail = GetComponent<SnakeTail>();
    }

    private void Start()
    {
        _headColor = GetComponent<MeshRenderer>().material;

        ColorUtility.ApplyColor(gameObject);

        ColorUpdated?.Invoke(_headColor.color);
        SegmentCollected?.Invoke(0);
        SizeUpdated?.Invoke(_tail.GetTailCount());
        DiamondCollected?.Invoke(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isFewerActive = GetComponent<SnakeMovement>().GetFewerState();

        if (other.TryGetComponent(out ColorChanger colorChange))
        {
            _headColor.color = colorChange.GetComponent<MeshRenderer>().material.color;
            ColorUpdated?.Invoke(_headColor.color);
        }

        switch (_isFewerActive)
        {
            case false:
                if (other.TryGetComponent(out Food food))
                {
                    if (other.GetComponent<MeshRenderer>().material.color == _headColor.color)
                    {
                        SegmentCollected?.Invoke(food.Collect());
                        SizeUpdated?.Invoke(_tail.GetTailCount());
                        ColorUpdated?.Invoke(_headColor.color);
                    }   
                    else
                    {
                        Destroy(gameObject);
                        GameReloader.RestartGame();
                    }
                }
                else if (other.TryGetComponent(out Diamond diamond))
                {
                    DiamondCollected?.Invoke(diamond.Collect());
                }
                else if (other.TryGetComponent(out Obstacle obstacle))
                {
                    Destroy(gameObject);
                    Destroy(other.gameObject);
                    GameReloader.RestartGame();
                }
                break;

            case true:
                if (other.TryGetComponent(out ColorChanger colorChange_1) == false)
                {
                    Destroy(other.gameObject);
                }
                break;
        }
    }
}
