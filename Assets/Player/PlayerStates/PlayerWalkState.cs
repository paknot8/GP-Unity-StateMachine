using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        // Implement if needed
        player.GetComponent<MeshRenderer>().material.color = new Color32(45, 115, 250, 255); // Dark Blue
    }

    public override void ExitState(Player player)
    {
        // Implement if needed
    }

    public override void UpdateState(Player player)
    {
        player.PlayerMovementCheck();
        
        if (player.isSprinting)
        {
            player.ChangeState(player.runState);
        }
            
        if (!player.IsGrounded())
        {
            player.ChangeState(player.fallState);
        }
    }
}
