using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public void StartGame()
    {
        ScoreManager.Instance.ResetScore();
        TimerManager.Instance.ResetTimer();
        TimerManager.Instance.StartTimer();
    }

    public void OnGameOver()
    {
        
    }

    void Start()
    {
        StartGame();
    }

}
