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
        // LoadLeaderboard();
    }

    private void LoadLeaderboard()
    {
        if (!PlayerPrefs.HasKey(HIGHSCORE_KEY))
        {
            highScoreData = new HighScoreData();
            Debug.Log("gak masuk");
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

    public HighScoreData GetHighScoreData()
    {
        return highScoreData;
    }

    public int CheckForNewHighScore(int score,string playerName)
    {
        bool hasPos = false;
        int yourPos = -1;
        Debug.Log("Check HighScore");
        int currentScore = score;
        DateTime currentDateLocal = DateTime.Now;
        string formattedDate = currentDateLocal.ToString("dd/MM/yy");

        string currentPlayerName = formattedDate;
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
            LoadLeaderboard();
        }

    }
}


[System.Serializable]
public class HighScoreData
{
    public ScoreData[] scoreDatas;

    public HighScoreData()
    {
        //initialize array sucks
        scoreDatas = new ScoreData[10]{
            new ScoreData(),
            new ScoreData(),
            new ScoreData(),
            new ScoreData(),
            new ScoreData(),
            new ScoreData(),
            new ScoreData(),
            new ScoreData(),
            new ScoreData(),
            new ScoreData()
        };
        
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
