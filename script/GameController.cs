using UnityEngine;

public class GameController : MonoBehaviour
{
    private LevelManager levelManager;
    private string currentLevel;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    public void LevelCompleted()
    {
        levelManager.CompleteLevel(currentLevel);
        levelManager.UnlockNextLevel(currentLevel);
    }
}
