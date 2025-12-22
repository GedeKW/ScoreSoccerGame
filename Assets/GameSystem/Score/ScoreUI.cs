using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text _textMessage;

    void Awake()
    {
        _textMessage = GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        ScoreManager.Instance.OnChangeScore+= HandleChangeScore;
    }

    void OnDestroy()
    {
        ScoreManager.Instance.OnChangeScore-= HandleChangeScore;
    }

    private void HandleChangeScore(int score)
    {
        _textMessage.text = "Score : " +score;
    }
}
