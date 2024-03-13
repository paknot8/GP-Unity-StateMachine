using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        // Orange
        player.GetComponent<MeshRenderer>().material.color = new Color32(250, 99, 45, 255);
    }

    public override void ExitState(Player player) => Debug.Log("Exit Falling state.");

    public override void UpdateState(Player player)
    {
        Debug.Log("Update currently falling state.");

        if(player.IsGrounded()){
            player.ChangeState(player.idleState);
        }
    }
}
