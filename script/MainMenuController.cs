using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // ������� ��� ������ ������ ���
    public void StartGame()
    {
        // ������ "GameScene" ������ ����� ���� ����� � ����
        SceneManager.LoadScene("LevelMenu");
    }

    // ������� ��� ������ ����� � ���
    public void ExitGame()
    {
        Application.Quit();
    }

    // ������� ��� ������ ������������ (����� ������ ����� �����)
    public void OpenSettings()
    {
        // ³������� ����������� - ��������� ����� �� �������
        Debug.Log("Open Settings");
    }
}
