using UnityEngine;

public class MoveCommandUp : Command
{
    private Vector2 direction;

    public MoveCommandUp(Vector2 direction)
    {
        this.direction = direction;
    }

    public override void Execute(RobotController2D robot)
    {
        robot.Move(direction);
    }
}
