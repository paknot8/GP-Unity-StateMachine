using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        // Implement if needed
    }

    public override void ExitState(Player player)
    {
        // Implement if needed
    }

    public override void UpdateState(Player player)
    {
        player.Movement();

        if (player.isSprinting)
            player.ChangeState(player.runState);

        if (!player.IsOnGroundCheck())
            player.ChangeState(player.fallState);
    }
}
