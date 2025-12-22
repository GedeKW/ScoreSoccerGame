using System.Collections;
using UnityEngine;

public class GameFinishedUI : MonoBehaviour
{
    public static GameFinishedUI Instance;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject interactables;
    [SerializeField] private GameObject nonInteractables;
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
            nonInteractables.SetActive(false);
        }

    }

    public void OpenGameFinishedUI()
    {
        StartCoroutine(OpenUI());
    }
    public void CloseGameFinishedUI()
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
        nonInteractables.SetActive(true);
        
        yield return null;
    }
    IEnumerator CloseUI()
    {
        interactables.SetActive(false);
        nonInteractables.SetActive(false);
        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha,0,1 / openDuration * Time.deltaTime);
            yield return null;    
        }
        

        yield return null;
    }

    public void OnClick_RestartGame()
    {
        CloseGameFinishedUI();
        GameManager.Instance.RestartGame();
    }

    public void OnClick_MainMenu()
    {
        CloseGameFinishedUI();
        GameManager.Instance.GoToMainMenu();
    }

    public void OnClick_HighScore()
    {
        GameManager.Instance.OpenHighScore();
    }
}
