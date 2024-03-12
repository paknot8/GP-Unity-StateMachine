using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        Debug.Log("Enter Falling state");
    }

    public override void ExitState(Player player)
    {
        Debug.Log("Exit falling state, landed on ground?");
    }

    public override void UpdateState(Player player)
    {
        if (player.IsOnGroundCheck())
        {
            player.ChangeState(player.idleState);
            player.jumpToFallDelta = player.jumpToFallTimer;
        } 
        else 
        {
            player.GetComponent<MeshRenderer>().material.color = new Color32(250, 99, 45, 255); // Orange
        }
    }
}
