using UnityEngine;

public class PlayerPrefManager : MonoBehaviour
{
    private static int MAX_ENTRIES = 10;
    bool canSave = true;

    

    public void SaveScore(string key,int score)
    {
        try
        {
            PlayerPrefs.SetInt(key,score);
        }
        catch
        {
            canSave = false;
        }
    }
}
