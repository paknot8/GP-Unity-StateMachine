using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        Debug.Log("Entering Idle");
    }

    public override void ExitState(Player player)
    {
        Debug.Log("Exiting Idle");
    }

    public override void UpdateState(Player player)
    {
        player.GetComponent<MeshRenderer>().material.color = new Color32(45, 215, 250, 255); // Light blue
        if (player.movement != Vector2.zero)
            player.ChangeState(player.walkState);

        if (!player.IsOnGroundCheck())
            player.ChangeState(player.fallState);
    }
}
