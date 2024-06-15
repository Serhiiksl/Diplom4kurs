using UnityEngine;

public class CutCommand : Command
{
    public override void Execute(RobotController2D robot)
    {
        robot.Cut();
    }
}
