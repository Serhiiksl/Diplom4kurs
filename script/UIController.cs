using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public CommandManager commandManager;
    public RobotController2D robot;
    public Text commandListText; // Використовуємо UnityEngine.UI.Text замість TMPro.TextMeshProUGUI
    public Text livesText; // Використовуємо UnityEngine.UI.Text для відображення життів
    public Text errorMessageText; // Додано для відображення повідомлень про помилки
    public Text successMessageText;
    public GameObject panel; // Панель, яку потрібно показувати або ховати
    public Button toggleButton; // Кнопка для показу/приховування панелі
    public Text toggleButtonText; // Текст на кнопці
    private bool isPanelActive = true;

    void Start()
    {
        UpdateLivesUI();
        UpdateCommandListUI(new Queue<Command>()); // Початкове оновлення списку команд
        ClearErrorMessage(); // Очистити повідомлення про помилки при запуску

    }
    public void DisplaySuccessMessage(string message)
    {
        successMessageText.text = message;
        successMessageText.gameObject.SetActive(true);
    }

    public void ClearSuccessMessage()
    {
        successMessageText.text = "";
        successMessageText.gameObject.SetActive(false);
    }
        public void DisplayErrorMessage(string message)
    {
        errorMessageText.text = message;
        errorMessageText.gameObject.SetActive(true);
    }

    public void ClearErrorMessage()
    {
        errorMessageText.text = "";
        errorMessageText.gameObject.SetActive(false);
    }


    public void OnMoveUpButton()
    {
        commandManager.AddCommand(new MoveCommandUp(Vector2.up));
    }

    public void OnMoveDownButton()
    {
        commandManager.AddCommand(new MoveCommandDown(Vector2.down));
    }

    public void OnMoveLeftButton()
    {
        commandManager.AddCommand(new MoveCommandLeft(Vector2.left));
    }

    public void OnMoveRightButton()
    {
        commandManager.AddCommand(new MoveCommandRigth(Vector2.right));
    }

    public void OnJumpButton()
    {
        commandManager.AddCommand(new JumpCommand());
    }

    public void OnShootButton()
    {
        commandManager.AddCommand(new ShootCommand());
    }

    public void OnCutButton()
    {
        commandManager.AddCommand(new CutCommand());
    }

    public void OnRunCommandsButton()
    {
        commandManager.ExecuteCommands();
    }

    public void OnClearCommandsButton()
    {
        commandManager.ClearCommands();
        UpdateCommandListUI(new Queue<Command>()); // Очищення списку команд в UI
    }

    public void UpdateCommandListUI(Queue<Command> commands)
    {
        commandListText.text = "Commands:\n";
        foreach (Command command in commands)
        {
            commandListText.text += command.GetType().Name + "\n";
        }
    }

    public void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + robot.lives;
        }
    }
    // Метод для перемикання видимості панелі
    public void TogglePanel()
    {
        isPanelActive = !isPanelActive;
        panel.SetActive(isPanelActive);
        toggleButtonText.text = isPanelActive ? "Hide Commands" : "Show Commands";
    }
    public void MenuSelectLevel()
    {
        // Замість "GameScene" вкажіть назву вашої сцени з грою
        SceneManager.LoadScene("LevelMenu");
    }

}
