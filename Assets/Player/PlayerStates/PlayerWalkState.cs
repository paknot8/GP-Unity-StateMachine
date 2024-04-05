using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        // Dark Blue
        player.GetComponent<MeshRenderer>().material.color = new Color32(45, 115, 250, 255);
        Debug.Log("Walk State");
    }

    public override void ExitState(Player player){}

    public override void UpdateState(Player player)
    {
        if (player.isSprinting) player.ChangeState(player.runState);
        if (!player.IsGrounded()) player.ChangeState(player.fallState);
        if (player.movement == Vector2.zero) player.ChangeState(player.idleState);
    }
}
