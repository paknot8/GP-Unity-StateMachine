using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

// TODO - Change color for Sprint, idle, Jumping
// TODO - Make Level
// TODO - Pick up coins
// TODO - Score Board
// TODO EXTRA - Enemy AI

public class MovementScript : MonoBehaviour
{
    // --- Basic Movement Variables -- //
    public float baseSpeed = 3;
    public float baseSpeedMultiplier = 3;
    public float rotationSpeed = 720;
    
    private bool isSprinting;

    // --- For Jumping --- //
    public float jumpPower = 8;
    public float ySpeed;

    // --- Audio Source --- //
    public AudioSource jumpSoundEffect; // serializefield is so you can drag a file in the inspector slot

    // References
    private Rigidbody rigidBody;
    private Vector3 vector;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = new(vector.x, 0f, vector.y);
        transform.Translate(baseSpeed * Time.deltaTime * movement);

        if(isSprinting){
            transform.Translate(baseSpeed * baseSpeedMultiplier * Time.deltaTime * movement);
        } else {
            transform.Translate(baseSpeed * Time.deltaTime * movement);
        }
    }

    void OnMove(InputValue value)
    {
        vector = value.Get<Vector2>();
        Debug.Log("Moving...");
    }

    void OnJump(InputValue value)
    {
        if(IsGrounded()){
            Debug.Log("Jumping...");
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpSoundEffect.Play();
        } else {
            Debug.Log("Can't Jump you are in the Air!");
        }
    }

    void OnRun(InputValue value){
        if(IsGrounded()){
            Debug.Log("Running...");
            if(value.isPressed){
                isSprinting = true;
            } else {
                isSprinting = false;
            }
        } else {
            Debug.Log("You are not on the ground!");
        }
    }

    private bool IsGrounded()
    {
        return rigidBody.velocity.y == 0;
    }

    void PlayerMovements()
    {
        Vector3 movement = new(vector.x, 0f, vector.y);
        transform.Translate(baseSpeed * Time.deltaTime * movement);
        Vector3 movementDirection = new(vector.x, 0, vector.z);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}