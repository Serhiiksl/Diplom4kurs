using UnityEngine;

public class MoveCommandDown : Command
{
    private Vector2 direction;

    public MoveCommandDown(Vector2 direction)
    {
        this.direction = direction;
    }

    public override void Execute(RobotController2D robot)
    {
        robot.Move(direction);
    }
}
