using System.Collections;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject interactables;
    [SerializeField] private float openDuration = 0.5f;
    [SerializeField] private float closeDuration = 0.2f;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            canvasGroup.alpha = 0;
            interactables.SetActive(false);
        }

    }

    public void OpenGameOverUI()
    {
        StartCoroutine(OpenUI());
    }
    public void CloseGameOverUI()
    {
        StartCoroutine(CloseUI());
    }
    IEnumerator OpenUI()
    {
        while(canvasGroup.alpha < 1)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha,1,1 / openDuration * Time.deltaTime);
            yield return null;    
        }
        interactables.SetActive(true);

        yield return null;
    }
    IEnumerator CloseUI()
    {
        interactables.SetActive(false);
        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha,0,1 / openDuration * Time.deltaTime);
            yield return null;    
        }
        

        yield return null;
    }

    //Button
    public void OnClick_Restart()
    {
        CloseGameOverUI();
        GameManager.Instance.RestartGame();
    }

    public void OnClick_MainMenu()
    {
        CloseGameOverUI();
        GameManager.Instance.GoToMainMenu();
    }

    public void OnClick_HighScore()
    {
        GameManager.Instance.OpenHighScore();
    }


}
