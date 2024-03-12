using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private readonly float forwardMovementSpeed = 4f; // Adjust the speed as needed

    public override void EnterState(Player player)
    {
        Debug.Log("Enter Falling state");
    }

    public override void ExitState(Player player)
    {
        Debug.Log("Exit falling state, landed on ground");
    }

    public override void UpdateState(Player player)
    {
        player.GetComponent<MeshRenderer>().material.color = new Color32(250, 99, 45, 255); // Orange
        Debug.Log("Update currently falling state.");

        // Move the player forward during the falling state only if there is movement input
        if (player.movement != Vector2.zero)
            MovePlayerWhenFalling(player);
        if (player.IsGrounded())
            player.ChangeState(player.idleState);
    }

    private void MovePlayerWhenFalling(Player player) => player.transform.Translate(forwardMovementSpeed * Time.deltaTime * player.transform.forward, Space.World);
}
