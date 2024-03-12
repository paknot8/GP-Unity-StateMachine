using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        Debug.Log("Entering Idle");
        player.GetComponent<MeshRenderer>().material.color = new Color32(45, 215, 250, 255); // Light blue
    }

    public override void ExitState(Player player)
    {
        Debug.Log("Exiting Idle");
    }

    public override void UpdateState(Player player)
    {
        if(!player.IsGrounded())
        {
            player.ChangeState(player.fallState);
        }

        if (player.movement != Vector2.zero)
        {
            player.ChangeState(player.walkState);
        }  
    }
}
