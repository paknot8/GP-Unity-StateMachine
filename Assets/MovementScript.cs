using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody RigidBodyPlayer;
    public float baseSpeed = 5;
    public float speedMultiplier = 8;
    public float jumpForce = 6;
    public float gravity = -10;
    public float rotationSpeed = 720;
    private bool isOnGround;

    // Bewegen van het object naar voren en achter en zuikant.
    private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        RigidBodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovements();
    }

    void PlayerMovements()
    {
        // Smooth movement of WASD and arrow keys
         // get player input for horizontal Axis and vertical
        float horizontalX = Input.GetAxis("Horizontal");
        float verticalZ = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontalX, 0, verticalZ); // input value for character move
        movementDirection.Normalize(); // ensure magnitude of 1
        

        // check if character is moving
        if(movementDirection != Vector3.zero)
        {
            // Type specific for storing rotations (use Vector3 up because of te Y axis)
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); // do the movement
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(movementDirection * (baseSpeed + speedMultiplier) * Time.deltaTime, Space.World);
        } 
        else
        {
            transform.Translate(movementDirection * baseSpeed * Time.deltaTime, Space.World); // Move to direction we want (real world time)
        }
        
        // if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        // {
        //     RigidBodyPlayer.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        //     Physics.gravity = new Vector3(0,gravity,0);
        // }
    }

    void OnCollisionEnter(Collision collision){
        isOnGround = true;
    }

    void OnCollisionExit(Collision collision){
        isOnGround = false;
    }
}
