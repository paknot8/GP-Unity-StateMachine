using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.GetComponent<MeshRenderer>().material.color = new Color32(45, 115, 250, 255); // Dark Blue
    }

    public override void ExitState(Player player){}

    public override void UpdateState(Player player)
    {
        player.PlayerMovementCheck();
        if (player.isSprinting)
            player.ChangeState(player.runState);
        if (!player.IsGrounded())
            player.ChangeState(player.fallState);
    }
}
