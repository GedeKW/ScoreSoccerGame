using System;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;
    public Action<float> OnChangeTime;

    [SerializeField] private float defaultTimer;

    private float _gameTimer;

    private bool _startTimer;
    private bool _timerFinished;

    public void StartTimer()
    {
        _startTimer = true;
        _timerFinished = false;
    }

    public void UpdateTime()
    {
        if(_gameTimer <= 0 && !_timerFinished)
        {
            OnTimeFinished();
        }
        if(!_startTimer) return;
        _gameTimer -= Time.deltaTime;
        OnChangeTime?.Invoke(Mathf.Max(0,_gameTimer));
    }

    private void OnTimeFinished()
    {
        _timerFinished = true;
        GameManager.Instance.GameFinished();

    }

    public void ResetTimer(float time = -1)
    {
        _startTimer = false;
        time = (time < 0)? defaultTimer : time;
        _gameTimer = time;
        OnChangeTime?.Invoke(_gameTimer);
    }

    public void PauseTimer(bool isPaused)
    {
        _startTimer = !isPaused;
    }

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            _gameTimer = defaultTimer;
        }

    }

    void Update()
    {
        UpdateTime();
    }
}
