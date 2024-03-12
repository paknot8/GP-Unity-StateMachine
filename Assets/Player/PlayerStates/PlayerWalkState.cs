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
        player.PlayerMovementCheck();

        player.GetComponent<MeshRenderer>().material.color = new Color32(45, 115, 250, 255); // Dark Blue
        if (player.isSprinting)
            player.ChangeState(player.runState);

        if (!player.IsOnGroundCheck())
            player.ChangeState(player.fallState);
    }
}
