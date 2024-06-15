using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public UIController uiController;
    public ScoreManager scoreManager;
    private LevelManager levelManager;
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(HandleFinishPointWithDelay());
        }
    }

    private IEnumerator HandleFinishPointWithDelay()
    {
        yield return new WaitForSeconds(1f);

        float time = Time.timeSinceLevelLoad;
        int score = CalculateScore(time);

        if (scoreManager != null)
        {
            string currentLevelName = SceneManager.GetActiveScene().name;
            scoreManager.SaveScore(currentLevelName, score, time);
            scoreManager.MarkLevelCompleted(currentLevelName);
        }
        else
        {
            Debug.LogError("ScoreManager is not assigned in FinishPoint.");
        }

        if (uiController != null)
        {
            uiController.DisplaySuccessMessage("You have reached the finish!");
        }
        else
        {
            Debug.LogError("UIController is not assigned in FinishPoint.");
        }

        yield return new WaitForSeconds(1f);

        LoadNextScene();
    }

    private int CalculateScore(float time)
    {
        int baseScore = 1000;
        int timePenalty = Mathf.FloorToInt(time) * 10;
        return Mathf.Max(baseScore - timePenalty, 0);
    }

    private void LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;

        int sceneNumber;
        if (int.TryParse(currentSceneName.Replace("Level", ""), out sceneNumber))
        {
            string nextSceneName = (sceneNumber + 1) + "Level";
            string openSceneName = (sceneNumber ) + "Level";
            Debug.Log("Attempting to load next scene: " + nextSceneName);
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
            {
                levelManager.UnlockNextLevel(openSceneName); // Відкрити перший рівень
                SceneManager.LoadScene(nextSceneName);
                Debug.Log("Loaded next scene: " + nextSceneName);
            }
            else
            {
                Debug.LogWarning("Next scene " + nextSceneName + " cannot be loaded. It may not exist.");
            }
        }
        else
        {
            Debug.LogError("Current scene name " + currentSceneName + " does not start with a valid number.");
        }
    }
}
