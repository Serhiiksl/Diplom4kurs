using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private const string LevelKeyPrefix = "Level_";
    private const string CompletedKeySuffix = "_Completed";

    public void CompleteLevel(string level)
    {
        PlayerPrefs.SetInt(LevelKeyPrefix + level + CompletedKeySuffix, 1);
        PlayerPrefs.Save();
    }

    public bool IsLevelCompleted(string level)
    {
        return PlayerPrefs.GetInt(LevelKeyPrefix + level + CompletedKeySuffix, 0) == 1;
    }

    public void UnlockNextLevel(string currentLevel)
    {
        int currentLevelNumber = int.Parse(currentLevel.Substring(0, currentLevel.Length - 5));
        string nextLevel = (currentLevelNumber + 1).ToString() + "Level";
        PlayerPrefs.SetInt(LevelKeyPrefix + nextLevel, 1);
        PlayerPrefs.Save();
    }

    public bool IsLevelUnlocked(string level)
    {
        return PlayerPrefs.GetInt(LevelKeyPrefix + level, 0) == 1;
    }

    public void LoadLevel(string level)
    {
        if (IsLevelUnlocked(level))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(level);
        }
    }
    public void MainMenuSelect()
    {
        // Замість "GameScene" вкажіть назву вашої сцени з грою
        SceneManager.LoadScene("MainMenu");
    }
}
