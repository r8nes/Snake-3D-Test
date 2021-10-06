using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DiamondScore : MonoBehaviour
{
    private int _scoreBeforeFewer = 3;
    private float _timerStartValue = 5f;

    [SerializeField] private int _score = 0;
    [SerializeField] private Text _amountView;

    private void OnScoreUpdated(int amount)
    {
        _score += amount;
        _amountView.text = _score.ToString();
    }

    public bool IsScoreEquals()
    {
        bool isEquals = _score >= _scoreBeforeFewer;

        if (isEquals == true)
        {
            if (_timerStartValue < 0)
            {
                ResetScore();
                _timerStartValue = 5f;
            }
            else 
            {
                _timerStartValue -= Time.deltaTime;
            }
        }
        return isEquals;
    }

    public void ResetScore()
    {
        _score = 0;
        OnScoreUpdated(_score);
    }

    private void OnEnable()
    {
        SnakeHead.DiamondCollected += OnScoreUpdated;
    }

    private void OnDisable()
    {
        SnakeHead.DiamondCollected -= OnScoreUpdated;
    }
}
