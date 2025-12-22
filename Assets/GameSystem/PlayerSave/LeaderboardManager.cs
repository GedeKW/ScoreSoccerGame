using UnityEngine;
using System.Linq;
using System;

public class LeaderboardManager : MonoBehaviour
{
   public static LeaderboardManager Instance;

   //Static Parameter

   [SerializeField] HighScoreData highScoreData;
    private const string HIGHSCORE_KEY = "HighScoreData";

    protected void Start()
    {
        LoadLeaderboard();
    }

    private void LoadLeaderboard()
    {
        if (!PlayerPrefs.HasKey(HIGHSCORE_KEY))
        {
            highScoreData = new HighScoreData();
            return;
        }

        HighScoreData loadedData = JsonUtility.FromJson<HighScoreData>(
            PlayerPrefs.GetString(HIGHSCORE_KEY)
        );
        highScoreData = loadedData;
            
    }

    private void DeleteLeaderBoard()
    {
         PlayerPrefs.DeleteAll();
    }

    private void SaveLeaderBoard(HighScoreData highScoreData)
    {
        string json = JsonUtility.ToJson(highScoreData);
        try
        {
            PlayerPrefs.SetString(HIGHSCORE_KEY, json);
            PlayerPrefs.Save();
        }
        catch
        {
            Debug.LogWarning("Data was not saved");
            //kasi info kalau belum ke saved
        }
    }

    public int CheckForNewHighScore(int score,string playerName)
    {
        bool hasPos = false;
        int yourPos = -1;
        Debug.Log("Check HighScore");
        int currentScore = score;
        string currentPlayerName = playerName;
        for(int i = 0; i < highScoreData.scoreDatas.Length; i++)
        {
            if(currentScore >= highScoreData.scoreDatas[i].score)
            {
                if (!hasPos)
                {
                    Debug.Log("new Score at pos " + (i+1).ToString());
                    hasPos = true;
                    yourPos = i+1;
                }
                
                int tempScore = highScoreData.scoreDatas[i].score;
                string tempName = highScoreData.scoreDatas[i].playerName;
                highScoreData.scoreDatas[i].score = currentScore;
                highScoreData.scoreDatas[i].playerName = currentPlayerName;
                currentScore = tempScore;
                currentPlayerName = tempName;
            }
        }

        SaveLeaderBoard(highScoreData);
        return yourPos;
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
            DontDestroyOnLoad(this.gameObject);
        }

    }
}


[System.Serializable]
public class HighScoreData
{
    public ScoreData[] scoreDatas;

    public HighScoreData()
    {
        scoreDatas = new ScoreData[10];
        for(int i = 0; i < 10; i++)
        {
            this.scoreDatas.Append(new ScoreData());
        }
        // the parameter for reference will be copied to all data
        // this.scoreDatas = Enumerable.Repeat(new ScoreData(), 10).ToArray();
    }

    public HighScoreData(ScoreData[] scoreDatas)
    {
        this.scoreDatas = scoreDatas;
    }
}


[System.Serializable]
public class ScoreData
{
    public string playerName = "";
    public int score = 0;
}
