using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    // Movement Variables
    public float moveSpeed;
    public float sprintSpeed;
    private Rigidbody rb;
    private bool sprinting;

    // Jumping Variables
    private int numberOfJumps;
    private int maxJumps = 3;
    protected float jumpHeight = 5;
    private bool isGrounded;
    private bool canJumpAgain;
    Vector3 jump = new Vector3(0, 2, 0);

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setting rb to the RigidBody component on this object
        rb = GetComponent<Rigidbody>();
        // Setting the number of jumps to 0
        numberOfJumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }

    private void FixedUpdate()
    {
        // If the key is pressed and we are not sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && !sprinting)
        {
            // Call the Sprint Function
            Sprint();
        }
        // If the key is released and we are sprinting 
        if (Input.GetKeyUp(KeyCode.LeftShift) && sprinting)
        {
            // Call the Move Player Function
            MovePlayer();
        }


    }
    // Updated every frame checking to see if object is colliding with the ground
    private void OnCollisionStay()
    {
        isGrounded = true;
        // Setting the number of jumps to 0
        numberOfJumps = 0;
    }

    void MovePlayer()
    {
        // Local float for the Input on the Horizontal axis
        float moveX = Input.GetAxis("Horizontal");
        //Local float for the Input on the Vertical axis
        float moveY = Input.GetAxis("Vertical");
        // Setting the sprinting bool to false
        sprinting = false;
        // Local Vector being set to a new Vector
        Vector3 movement = new Vector3(moveX, 0, moveY);
        // Adding force to the rigidbody 
        rb.AddForce(movement * moveSpeed);

    }

    void Sprint()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        sprinting = true;
        Vector3 movement = new Vector3(moveX, 0, moveY);

        rb.AddForce(movement * sprintSpeed);
    }

    void Jump()
    {
        // If the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Setting isGrounded bool to false
            isGrounded = false;
            // If the number of jumps is less than the max jumps
            if (numberOfJumps < maxJumps)
            {
                //Setting our can jump again bool to true
                canJumpAgain = true;
                //Incrementing the number of jumps
                numberOfJumps++;
            }
            //  If the number of jumps is not less than 
            else
            {
                // Setting the can jump again bool to false
                canJumpAgain = false;
            }
            // If we can jump again
            if (canJumpAgain)
            {
                // We jump
                rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            }
        }
    }

}
