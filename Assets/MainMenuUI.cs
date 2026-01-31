using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
   public static MainMenuUI Instance;
   [SerializeField] private GameObject menuUI;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void OnClick_StartGame()
    {
        menuUI.SetActive(false);
        GameManager.Instance.StartGame();
    }

    public void OpenMainMenu()
    {
        menuUI.SetActive(true);
    }
}
