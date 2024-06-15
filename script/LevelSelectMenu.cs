using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    public Text[] levelResultsTexts;

    private void Start()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene.");
            return;
        }

        int completedLevels = scoreManager.GetCompletedLevels();
        Debug.Log("Completed Levels: " + completedLevels);

        for (int i = 0; i < levelResultsTexts.Length; i++)
        {
            int levelIndex = i + 1;
            string levelName = levelIndex + "Level";

            if (levelResultsTexts[i] == null)
            {
                Debug.LogError($"Text element for {levelName} is not assigned in the inspector.");
                continue;
            }

            int score = scoreManager.GetScore(levelName);
            float time = scoreManager.GetTime(levelName);

            levelResultsTexts[i].text = $"{levelName}\nScore: {score}\nTime: {time:F2}s";
            levelResultsTexts[i].color = (levelIndex <= completedLevels) ? Color.white : Color.gray;
        }
    }
}
