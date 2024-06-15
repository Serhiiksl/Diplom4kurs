using UnityEngine;

public class JumpCommand : Command
{
    public override void Execute(RobotController2D robot)
    {
        robot.Jump();
    }
}
