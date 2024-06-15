using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Функція для кнопки Почати гру
    public void StartGame()
    {
        // Замість "GameScene" вкажіть назву вашої сцени з грою
        SceneManager.LoadScene("LevelMenu");
    }

    // Функція для кнопки Вихід з гри
    public void ExitGame()
    {
        Application.Quit();
    }

    // Функція для кнопки Налаштування (можна додати логіку пізніше)
    public void OpenSettings()
    {
        // Відкриття налаштувань - реалізуйте пізніше за потреби
        Debug.Log("Open Settings");
    }
}
