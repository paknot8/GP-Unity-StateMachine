using UnityEngine;

public partial class EnemyManagement
{
    public float healthPoints;
    public float timerDuration;
    public float pushForce;
    public float friction;
    private float maxHeight;

    private bool isKnockedBack;
    private bool isCollisionCooldown;
    public float collisionCooldown;
}