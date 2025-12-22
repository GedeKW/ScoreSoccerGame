using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    public static LeaderboardUI Instance;
    [SerializeField] List<TMP_Text> scoreTexts;

    [SerializeField] GameObject UICanvas;

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

    private void UpdateLeaderboardUI()
    {
        HighScoreData highScoreData = LeaderboardManager.Instance.GetHighScoreData();
        for(int i = 0; i < scoreTexts.Count; i++)
        {
            string playerName = highScoreData.scoreDatas[i].playerName;
            int score = highScoreData.scoreDatas[i].score;
            if(playerName == "")
            {
                playerName ="N/a";
            }
            scoreTexts[i].text = (i+1).ToString()+". "+playerName+" "+score;
        }
    }

    void Start()
    {
        UpdateLeaderboardUI();
    }

    public void OnClick_Close()
    {
        CloseLeaderboardUI();
    }

    public void CloseLeaderboardUI()
    {
        UICanvas.SetActive(false);
    }

    public void OpenLeaderboardUI()
    {
        UpdateLeaderboardUI();
        UICanvas.SetActive(true);
    }

}
