using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public CommandManager commandManager;
    public RobotController2D robot;
    public Text commandListText; // ������������� UnityEngine.UI.Text ������ TMPro.TextMeshProUGUI
    public Text livesText; // ������������� UnityEngine.UI.Text ��� ����������� �����
    public Text errorMessageText; // ������ ��� ����������� ���������� ��� �������
    public Text successMessageText;
    public GameObject panel; // ������, ��� ������� ���������� ��� ������
    public Button toggleButton; // ������ ��� ������/������������ �����
    public Text toggleButtonText; // ����� �� ������
    private bool isPanelActive = true;

    void Start()
    {
        UpdateLivesUI();
        UpdateCommandListUI(new Queue<Command>()); // ��������� ��������� ������ ������
        ClearErrorMessage(); // �������� ����������� ��� ������� ��� �������

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
        UpdateCommandListUI(new Queue<Command>()); // �������� ������ ������ � UI
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
    // ����� ��� ����������� �������� �����
    public void TogglePanel()
    {
        isPanelActive = !isPanelActive;
        panel.SetActive(isPanelActive);
        toggleButtonText.text = isPanelActive ? "Hide Commands" : "Show Commands";
    }
    public void MenuSelectLevel()
    {
        // ������ "GameScene" ������ ����� ���� ����� � ����
        SceneManager.LoadScene("LevelMenu");
    }

}
