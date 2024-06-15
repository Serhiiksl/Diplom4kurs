using UnityEngine;

public class MoveCommandRigth : Command
{
    private Vector2 direction;

    public MoveCommandRigth(Vector2 direction)
    {
        this.direction = direction;
    }

    public override void Execute(RobotController2D robot)
    {
        robot.Move(direction);
    }
}
