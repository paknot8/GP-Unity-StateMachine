using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        // Orange
        player.GetComponent<MeshRenderer>().material.color = new Color32(250, 99, 45, 255);
        Debug.Log("Fall State");
    }

    public override void ExitState(Player player) {}
    
    public override void UpdateState(Player player)
    {
        player.PlayerMovement();
        if(player.IsGrounded())
            player.ChangeState(player.idleState);
    }
}
