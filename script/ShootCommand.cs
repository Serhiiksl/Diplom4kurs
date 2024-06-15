using UnityEngine;

public class ShootCommand : Command
{
    public override void Execute(RobotController2D robot)
    {
        robot.Shoot();
    }
}
