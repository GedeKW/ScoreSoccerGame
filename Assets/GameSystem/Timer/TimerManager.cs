using System;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;
    public Action<float> OnChangeTime;

    [SerializeField] private float defaultTimer;

    private float _gameTimer;

    private bool _startTimer;

    public void StartTimer()
    {
        _startTimer = true;
    }

    public void UpdateTime()
    {
        
        if(!_startTimer) return;
        _gameTimer -= Time.deltaTime;
        OnChangeTime?.Invoke(Mathf.Max(0,_gameTimer));
    }

    public void ResetTimer(float time = -1)
    {
        _startTimer = false;
        time = (time < 0)? defaultTimer : time;
        _gameTimer = time;
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
