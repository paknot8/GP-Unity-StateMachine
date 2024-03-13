using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        // Purple
        player.GetComponent<MeshRenderer>().material.color = new Color32(152, 45, 250, 255);
    }

    public override void ExitState(Player player){}

    public override void UpdateState(Player player)
    {
        player.PlayerMovement();
        if (player.movement == Vector2.zero) 
            player.ChangeState(player.idleState);
        if (!player.isSprinting) 
            player.ChangeState(player.walkState);
    }
}
