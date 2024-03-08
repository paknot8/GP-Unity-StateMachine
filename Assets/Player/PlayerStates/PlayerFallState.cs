using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        Debug.Log("Enter Falling state");
    }

    public override void ExitState(Player player)
    {
        Debug.Log("Exit falling state, landed on ground?");
    }

    public override void UpdateState(Player player)
    {
        Debug.Log("Player is falling...");
        if (player.IsOnGroundCheck())
        {
            Debug.Log("Is on ground check to idle?");
            player.ChangeState(player.walkState);
        }
    }
}