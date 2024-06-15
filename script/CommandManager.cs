using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandManager : MonoBehaviour
{
    private Queue<Command> commands = new Queue<Command>();
    public RobotController2D robot;
    public UIController uiController;
    public Button[] buttons;
    public Animator animator;

    public void AddCommand(Command command)
    {
        commands.Enqueue(command);
        uiController.UpdateCommandListUI(commands); // Оновити UI список команд
    }

    public void ExecuteCommands()
    {
        if (commands.Count > 0)
        {
            StartCoroutine(ExecuteCommandQueue());
        }
    }

    public void ClearCommands()
    {
        commands.Clear();
        uiController.UpdateCommandListUI(commands); // Очищення списку команд в UI
    }

    private IEnumerator ExecuteCommandQueue()
    {
        BlockButtons(true);

        while (commands.Count > 0)
        {
            Command currentCommand = commands.Dequeue();
            currentCommand.Execute(robot);
            uiController.UpdateCommandListUI(commands); // Оновити UI список команд
            yield return new WaitWhile(() => robot.isMoving); // Затримка між командами
        }
        
            
            animator.SetTrigger("Idle");
        

        BlockButtons(false);
    }

    private void BlockButtons(bool block)
    {
        foreach (Button button in buttons)
        {
            button.interactable = !block;
        }
    }
}
