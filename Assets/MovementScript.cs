using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody RigidBodyPlayer;
    public float baseSpeed = 3;
    public float speedMultiplier = 2;
    public float jumpForce = 6;
    public float gravity = -10;
    private bool isOnGround;

    // Bewegen van het object naar voren en achter en zuikant.
    private Vector3 movement;

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
        float horizontalX = Input.GetAxis("Horizontal");
        float verticalZ = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalX, 0, verticalZ);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            movement *= baseSpeed + speedMultiplier;
        } 
        else
        {
            movement *= baseSpeed;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            RigidBodyPlayer.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Physics.gravity = new Vector3(0,gravity,0);
        }
        transform.Translate(movement * baseSpeed * Time.deltaTime); 
    }

    void OnCollisionEnter(Collision collision){
        isOnGround = true;
    }

    void OnCollisionExit(Collision collision){
        isOnGround = false;
    }
}
