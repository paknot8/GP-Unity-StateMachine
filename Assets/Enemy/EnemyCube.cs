using UnityEngine;

public class EnemyCube : Enemy
{
    protected override void Update()
    {
        // Additional logic specific to EnemyCube
        base.Update();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        // Additional logic specific to EnemyCube
        base.OnTriggerEnter(other);
    }
    
    // Add or override more methods as needed for the EnemyCube class
}
