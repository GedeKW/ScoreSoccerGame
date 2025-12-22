using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    // Time Left: 
    private TMP_Text _textMessage;

    void Awake()
    {
        _textMessage = GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        TimerManager.Instance.OnChangeTime+= HandleChangeTime;
    }

    private void HandleChangeTime(float time)
    {
        // _textMessage.text = "Time Left: " +time.ToString("F0");
        _textMessage.text = time.ToString("F0");
    }
}
