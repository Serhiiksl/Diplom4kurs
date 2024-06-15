using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    public Sprite unlockedSprite; // Спрайт для відкритих рівнів
    public Sprite lockedSprite; // Спрайт для закритих рівнів

    void Start()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            string level = (i + 1).ToString() + "Level";
            Button button = levelButtons[i];
            if (levelManager.IsLevelUnlocked(level))
            {
                button.interactable = true;
                button.GetComponent<Image>().sprite = unlockedSprite;
                button.onClick.AddListener(() => levelManager.LoadLevel(level));
            }
            else
            {
                button.interactable = false;
                button.GetComponent<Image>().sprite = lockedSprite;
            }
        }
    }
}
