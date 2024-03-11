using UnityEngine;

public class EnemyCube : Enemy
{
    // No need for the 'new' keyword here

    protected override void Update()
    {
        // Additional logic specific to EnemyCube can be added here

        // Call the base class Update method to maintain common functionality
        base.Update();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        // Additional logic specific to EnemyCube can be added here

        // Call the base class OnTriggerEnter method to maintain common functionality
        base.OnTriggerEnter(other);
    }

    // Override or add more methods as needed for the EnemyCube class
}