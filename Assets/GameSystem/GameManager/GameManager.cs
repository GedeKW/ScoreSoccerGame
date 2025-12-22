using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentGameState {get; private set;}

    public Action<GameState> OnChangeState;

    [SerializeField] TMP_Text readyText;

    //LifeCycle
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            // DontDestroyOnLoad(this.gameObject);
        }

    }
    
    void Start()
    {
        StartGame();
    }

    //GameState Controller
    public void StartGame()
    {
        ScoreManager.Instance.ResetScore();
        TimerManager.Instance.ResetTimer();
        BallManager.Instance.RestartBall();
        StartGameCountDown();
        
    }

    

    private void StartGameCountDown()
    {
        StartCoroutine(StartGame_Corr());
    }

    private IEnumerator StartGame_Corr()
    {
        float timer = 3;
        
        readyText.text = timer.ToString("F0");
        readyText.gameObject.SetActive(true);
        while(timer >= 0)
        {
            timer -= Time.deltaTime;
            readyText.text = Mathf.Max(timer,0).ToString("F0");
            yield return null;
        }
        readyText.gameObject.SetActive(false);
        readyText.text = "3";
        ChangeState(GameState.playGame);
        BallManager.Instance.DropBall();
        ScoreManager.Instance.EnableScoring(true);
        TimerManager.Instance.StartTimer();
        AddTimerManager.Instance.StartSpawnAddTimerManager();
        yield return null;
    }



    public void GameOver()
    {
        if(GameIsFinished()) return;
        ChangeState(GameState.gameOver);
        AddTimerManager.Instance.StopSpawnAddTimerManager();
        ScoreManager.Instance.EnableScoring(false);
        TimerManager.Instance.PauseTimer(true);
        GameOverUI.Instance.OpenGameOverUI();

    }

    public void GameFinished()
    {
        if(GameIsFinished()) return;
        ChangeState(GameState.gameFinished);
        AddTimerManager.Instance.StopSpawnAddTimerManager();
        ScoreManager.Instance.EnableScoring(false);
        int score = ScoreManager.Instance.CurrentScore;
        LeaderboardManager.Instance.CheckForNewHighScore(score,"player");
        GameFinishedUI.Instance.OpenGameFinishedUI();
        
    }

    public void ChangeState(GameState targetGameState)
    {
        CurrentGameState = targetGameState;
        OnChangeState?.Invoke(targetGameState);
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void GoToMainMenu()
    {
        ChangeState(GameState.menu);
    }

    public void OpenHighScore()
    {
        LeaderboardUI.Instance.OpenLeaderboardUI();
    }
    

    private bool GameIsFinished()
    {
        return CurrentGameState == GameState.gameFinished || CurrentGameState == GameState.gameOver;
    }

}

public enum GameState
{
    menu,
    enterGame,
    playGame,
    pauseGame,
    gameOver,
    gameFinished,


}
