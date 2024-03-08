using UnityEngine;

public class PlayerHitState : PlayerBaseState
{
    public override void EnterState(Player player) {
        Debug.Log("Entering Hit");
    }

    public override void ExitState(Player player) {
        Debug.Log("Exiting Hit");
    }

    public override void UpdateState(Player player)
    {
        Debug.Log("Hitting...");
    }
}