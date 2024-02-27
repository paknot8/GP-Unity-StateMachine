using UnityEngine;

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

    // --- For Jumping --- //
    public float jumpSpeed = 8;
    public float ySpeed;

    // --- Audio Source --- //
    public AudioSource jumpSoundEffect; // serializefield is so you can drag a file in the inspector slot

    // References
    private CharacterController characterController;

    // Enum for player states
    public enum PlayerState
    {
        Idle,Moving,Running,Jumping
    }

    private PlayerState currentState;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Initialize state machine
        currentState = PlayerState.Idle;
    }

    void Update()
    {
        PlayerMovements();
        UpdateState(); // Add this to update the state machine
    }

    void PlayerMovements()
    {
        float horizontalX = Input.GetAxis("Horizontal");
        float verticalZ = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalX, 0, verticalZ);

        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * baseSpeed;
        movementDirection.Normalize();

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
                ySpeed = jumpSpeed;
                SetState(PlayerState.Jumping); // Transition to Jumping state
            }
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            SetState(PlayerState.Running); // Transition to Running state
            characterController.SimpleMove(movementDirection * magnitude * baseSpeedMultiplier);
        }
        else
        {
            if (currentState != PlayerState.Jumping) // Avoid changing state while jumping
                SetState(PlayerState.Moving); // Transition to Moving state

            characterController.SimpleMove(movementDirection * magnitude);
        }
    }

    // Function to update the state machine
    void UpdateState()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                // Add color or visual changes for Idle state
                break;

            case PlayerState.Moving:
                // Add color or visual changes for Moving state
                break;

            case PlayerState.Running:
                // Add color or visual changes for Running state
                break;

            case PlayerState.Jumping:
                // Add color or visual changes for Jumping state
                break;
        }
    }

    // Function to set the current state and perform state-specific actions
    void SetState(PlayerState newState)
    {
        currentState = newState;

        // Perform state-specific actions
        switch (currentState)
        {
            case PlayerState.Idle:
                // Additional actions for Idle state, if needed
                break;

            case PlayerState.Moving:
                // Additional actions for Moving state, if needed
                break;

            case PlayerState.Running:
                // Additional actions for Running state, if needed
                break;

            case PlayerState.Jumping:
                // Additional actions for Jumping state, if needed
                break;
        }
    }
}