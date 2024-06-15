using UnityEngine;

public class MoveCommandLeft : Command
{
    private Vector2 direction;

    public MoveCommandLeft(Vector2 direction)
    {
        this.direction = direction;
    }

    public override void Execute(RobotController2D robot)
    {
        robot.Move(direction);
    }
}
