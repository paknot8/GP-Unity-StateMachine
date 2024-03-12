using UnityEngine;

public class PlayerRunState : PlayerBaseState
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
        player.GetComponent<MeshRenderer>().material.color = new Color32(152, 45, 250, 255); // Purple
        if (player.movement == Vector2.zero) player.ChangeState(player.idleState);
        if (!player.isSprinting) player.ChangeState(player.walkState);
    }
}
