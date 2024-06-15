using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RobotController2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;
    public int Maxlives = 3;
    public int lives;
    public Text livesText; // ������������� UnityEngine.UI.Text ������ TMPro.TextMeshProUGUI
    public LayerMask obstacleLayer;
    public UIController uiController;
    private Vector2 startPos;
    private Vector2 fstartPos;
    private bool isMovingLeft = true; // �� ������������� �������� ����
    public Text messageText; // ��������� ������� ��� ����������� ����������
    public ScoreManager scoreManager;
    void Start()
    {
        startPos = transform.position;
        fstartPos = transform.position;
        lives = Maxlives;
        UpdateLivesUI();
    }

    public bool isMoving = false;

    public void Move(Vector2 direction)
    {
        StartCoroutine(MoveRoutine(direction));
    }

    private IEnumerator MoveRoutine(Vector2 direction)
    {
        isMoving = true;
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + direction*1.28f;

        // ���������� ���������� �������� �������
        SetMoveAnimation(direction);

        float elapsedTime = 0;
        if (!IsBlocked(endPos))
        {
            while (elapsedTime < 1f)
            {
                transform.position = Vector2.Lerp(startPos, endPos, elapsedTime);
                elapsedTime += Time.deltaTime * moveSpeed;
                yield return null;
            }

            transform.position = endPos;
            isMoving = false;
            animator.SetBool("IsMoving", false); // �������� ������� ����
        }
        else
        {
            Debug.Log("Movement blocked! Simulation restarting...");
            uiController.DisplayErrorMessage("Movement blocked! Simulation restarting...");
            StartCoroutine(HandleError());
        }
        DecreaseLives();
    }
    private IEnumerator HandleError()
    {
        yield return new WaitForSeconds(2f);
        RestartGame();
    }
    private void RestartGame()
    {
        lives = Maxlives; // ³��������� ������� ����� �� ������������� ��������
        uiController.UpdateLivesUI();
        transform.position = fstartPos; // ��������� ������ �� ��������� �������
        isMoving = false;
        uiController.ClearErrorMessage();
    }
    private bool IsBlocked(Vector2 position)
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(position, 0.0000001f, obstacleLayer);
        return hitCollider != null;
    }

    private void SetMoveAnimation(Vector2 direction)
    {
        if (direction == Vector2.up)
        {
            animator.SetTrigger("MoveUp");
        }
        else if (direction == Vector2.down)
        {
            animator.SetTrigger("MoveDown");
        }
        else if (direction == Vector2.left)
        {
            isMovingLeft = true;
            animator.SetTrigger("MoveLeft");
            GetComponent<SpriteRenderer>().flipX = false; // ���������� �������� ��� ���� ����
        }
        else if (direction == Vector2.right)
        {
            isMovingLeft = false;
            animator.SetTrigger("MoveLeft"); // ������������� �� � �������, �� � ��� ���� ����
            GetComponent<SpriteRenderer>().flipX = true; // ���������� ���������� ������ ��� ���� ������
        }

        animator.SetBool("IsMoving", true);
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
        // ����� ��� �������
        if (!isMoving && lives > 0)
        {
            // ����� ��� �������
            DecreaseLives();
        }
        Debug.Log("Jumping!");
        // �������� ������� ������� ��� ���� 䳿
    }

    public void Shoot()
    {
        animator.SetTrigger("Shoot");
        // ����� ��� �������
        if (!isMoving && lives > 0)
        {
            // ����� ��� �������
            DecreaseLives();
        }
        Debug.Log("Shooting!");
        // �������� ������� ������� ��� ���� 䳿
    }

    public void Cut()
    {
        animator.SetTrigger("Cut");
        // ����� ��� ������
        if (!isMoving && lives > 0)
        {
            // ����� ��� �������
            DecreaseLives();
        }
        Debug.Log("Cutting!");
        // �������� ������� ������ ��� ���� 䳿
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
    private void ShowMessage(string message, float duration)
    {
        StartCoroutine(ShowMessageRoutine(message, duration));
    }

    private IEnumerator ShowMessageRoutine(string message, float duration)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        messageText.gameObject.SetActive(false);
    }

    private void DecreaseLives()
    {
        if (lives >= 0)
        {
            lives--;
            

            if (lives < 0)
            {
                ShowMessage("Game Over: Too many steps!", 2f);
                StartCoroutine(ResetRobot());
            }
            if (lives >= 0)
                UpdateLivesUI();
        }
    }

    private IEnumerator ResetRobot()
    {
        yield return new WaitForSeconds(2f);
        rb.position = fstartPos;
        lives = Maxlives; // ��� �������������� ��������� �������� �����, ��� �� ������
        UpdateLivesUI();
    }
}
