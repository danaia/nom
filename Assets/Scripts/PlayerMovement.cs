using UnityEngine;
//add animator


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;      // Move speed of the player
    [SerializeField] private float jogSpeedMultiplier = 1.5f;  // Speed multiplier when jogging
    [SerializeField] private KeyCode jogKey = KeyCode.LeftShift; // Key for jogging

    private Rigidbody2D rb2d;       // Reference to the Rigidbody2D component
    private Vector2 movementInput; // Movement input from player

    private Animator animator;
    private bool isMoving = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get movement input from player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector2(horizontal, vertical);

        if (horizontal != 0 || vertical != 0)
        {
            isMoving = true;
      
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);

        

        // Apply speed multiplier when jogging
        if (Input.GetKey(jogKey))
        {
            movementInput *= jogSpeedMultiplier;
        }
    }

    void FixedUpdate()
    {
        // Move the player using Rigidbody2D velocity
        Vector2 moveVelocity = movementInput * moveSpeed * Time.fixedDeltaTime;
        rb2d.velocity = moveVelocity;
    }
}

