using UnityEngine;

public class Initializer : MonoBehaviour
{
    void Start()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (!levelManager.IsLevelUnlocked("1Level"))
        {
            levelManager.UnlockNextLevel("0Level"); // Відкрити перший рівень
        }
    }
}
