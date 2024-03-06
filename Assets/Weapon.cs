

using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float slashSpeed = 100f; // Adjust the speed of the slash

    private bool slashingUp = true; // Flag to determine whether to slash up or down

    // Update is called once per frame
    void Update()
    {
        // Check if the weapon is slashing up or down
        float slashDirection = slashingUp ? 1f : -1f;

        // Calculate the rotation angle based on time and speed
        float rotationAngle = slashDirection * slashSpeed * Time.deltaTime;

        // Rotate the weapon around its local Y-axis
        transform.Rotate(Vector3.up, rotationAngle);

        // Change the slash direction when reaching a certain angle (e.g., 45 degrees)
        if (Mathf.Abs(transform.localRotation.eulerAngles.y) > 45f)
        {
            slashingUp = !slashingUp;
        }
    }
}