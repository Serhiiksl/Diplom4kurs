using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public CommandManager commandManager;

    public void OnMoveForward()
    {
        commandManager.AddCommand(new MoveCommandUp(Vector2.up));
    }

    public void OnMoveBackward()
    {
        commandManager.AddCommand(new MoveCommandDown(Vector2.down));
    }

    public void OnMoveLeft()
    {
        commandManager.AddCommand(new MoveCommandLeft(Vector2.left));
    }

    public void OnMoveRight()
    {
        commandManager.AddCommand(new MoveCommandRigth(Vector2.right));
    }

    public void OnJump()
    {
        commandManager.AddCommand(new JumpCommand());
    }

    public void OnShoot()
    {
        commandManager.AddCommand(new ShootCommand());
    }

    public void OnCut()
    {
        commandManager.AddCommand(new CutCommand());
    }

    public void OnRunCommands()
    {
        commandManager.ExecuteCommands();
    }

    public void OnClearCommands()
    {
        commandManager.ClearCommands();
    }
}
