using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore = 0;

    public static ScoreManager Instance;

    public Action<int> OnChangeScore;

    private bool _canScore;

    public int CurrentScore => _currentScore;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    public void AddScore(int score = 1)
    {
        if(!_canScore) return;
        _currentScore += score;
        OnChangeScore?.Invoke(_currentScore);
    }

    public void ResetScore()
    {
        _currentScore = 0;
        OnChangeScore?.Invoke(_currentScore);
    }

    public void EnableScoring(bool enableScore)
    {
        _canScore = enableScore;
    }
}
