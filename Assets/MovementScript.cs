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
    private CharacterController characterController;
    private Rigidbody rigidBody;
    private Vector3 vector;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(vector.x, 0f, vector.y);
        if(isSprinting){
                transform.Translate(movement * baseSpeed * baseSpeedMultiplier * Time.deltaTime);
        } else {
            transform.Translate(movement * baseSpeed * Time.deltaTime);
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
        Vector3 movement = new Vector3(vector.x, 0f, vector.y);
        transform.Translate(movement * baseSpeed * Time.deltaTime);
        Vector3 movementDirection = new(vector.x, 0, vector.z);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (characterController.isGrounded)
        {
            ySpeed = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpSoundEffect.Play();
                ySpeed = jumpPower;
            }
        }

        Vector3 velocity = movementDirection;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.SimpleMove(movementDirection * baseSpeedMultiplier);
        }
        else
        {
            characterController.SimpleMove(movementDirection);
        }
    }
}