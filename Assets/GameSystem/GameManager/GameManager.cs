using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentGameState {get; private set;}

    public Action<GameState> OnChangeState;

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
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        ChangeState(GameState.playGame);
        BallManager.Instance.DropBall();
        ScoreManager.Instance.EnableScoring(true);
        TimerManager.Instance.StartTimer();
        yield return null;
    }



    public void GameOver()
    {
        if(GameIsFinished()) return;
        ChangeState(GameState.gameOver);
        ScoreManager.Instance.EnableScoring(false);
        TimerManager.Instance.PauseTimer(true);
        GameOverUI.Instance.OpenGameOverUI();

    }

    public void GameFinished()
    {
        if(GameIsFinished()) return;
        ChangeState(GameState.gameFinished);
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
