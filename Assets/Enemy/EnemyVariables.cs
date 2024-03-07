using UnityEngine;

public partial class EnemyManagement
{
    public float healthPoints;
    public float timerDuration;
    public float pushForce;
    public float friction;
    private float maxHeight;

    public bool isKnockedBack;
    public bool isCollisionCooldown;
    public float collisionCooldown;
}