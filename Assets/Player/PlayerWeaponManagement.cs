using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float slashSpeed = 100f; // Adjust the speed of the slash
    private bool slashing = true;

    // Update is called once per frame
    void Update()
    {
        DoSlash();
    }

    private void DoSlash()
    {
        float slashDirection = slashing ? 1f : -1f; // Check if the weapon is slashing
        float rotationAngle = slashDirection * slashSpeed * Time.deltaTime; // Calculate the rotation angle based on time and speed
        transform.Rotate(Vector3.up, rotationAngle); // Rotate the weapon around its local Y-axis

        if (Mathf.Abs(transform.localRotation.eulerAngles.y) > 45f)// Change the slash direction when reaching a certain angle
        { 
            slashing = !slashing;
        }
    }
}