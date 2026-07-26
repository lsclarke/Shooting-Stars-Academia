using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private StarBoy starBoy;
    private Rigidbody2D rb;
    //Movement Variables
    private float moveSpeed;
    private Vector2 moveDirection;
    private float MAXMOVESPEED = 10f;

    //References to additional scripts
    [SerializeField]
    private PlayerStamina playerStamina;

    //Bool conditional variables
    private bool isWalking;
    private bool isRunning;
    private bool isHalting;
    private bool isGrounded;
    private bool canJump;
    private bool isJumping;

    //Ground Detection variables
    [SerializeField]
    private float groundCheckerRadius;
    [SerializeField]
    private Transform groundChecker;
    [SerializeField]
    private LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 0f;
        rb = GetComponent<Rigidbody2D>();
        isWalking = true;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveSpeed);
        SpeedAcceleration();
        Friction();

        //Ground detection logic
        if (OnGround())
        {
            isGrounded = true;
            canJump = true;
        }
        else
        {
            isGrounded = false;
            canJump = false;
        }

    }

    public bool OnGround()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);
    }

    public bool Walking()
    {
        return isWalking;
    }

    public bool Running()
    {
        return isRunning;
    }

    public Rigidbody2D getRigidbody2D()
    {
        return rb;
    }

    private void Friction()
    {
        //Speed limit control
        if (Mathf.Abs(rb.linearVelocityX) > 0f)
        {
            float continuedMovement = moveDirection.x * moveSpeed;
            continuedMovement = -0.00001f;
            rb.linearVelocity = new Vector2(continuedMovement, rb.linearVelocityY);
        }
    }

    private void SpeedAcceleration()
    {
        const float acceleration = 55.5f;
        const float deceleration = 55.5f;

        if (moveDirection.x == 0f)
        {
            moveSpeed -= Time.deltaTime * deceleration;

            if (moveSpeed <= 0f)
            {
                moveSpeed = 0f;
            }
        }

        if (Mathf.Abs(moveDirection.x) >= 1f )
        {
            if (isWalking)
            {
                moveSpeed += Time.deltaTime * acceleration;

                if (Mathf.Abs(moveSpeed) >= starBoy.walkSpeed)
                {
                    moveSpeed = starBoy.walkSpeed;
                }
            }
        }

        if (Mathf.Abs(moveDirection.x) >= 1f)
        {
            if (isRunning)
            {
                moveSpeed += Time.deltaTime * acceleration;

                if (Mathf.Abs(moveSpeed) >= starBoy.runSpeed)
                {
                    moveSpeed = starBoy.runSpeed;
                }
            }
        }
    }

    private void PlayerJump()
    {
        if (canJump)
        {
            Vector2 jumpDirection = new Vector2(rb.linearVelocityX, starBoy.jumpForce);
            rb.AddForce(jumpDirection, ForceMode2D.Impulse);
        }
        else return;
    }

    public Vector2 getMoveDirection()
    {
        return moveDirection;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void Run(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isRunning = true;
            isWalking = false;

            Invoke("PlayerRun", 0.01f);
        }
        else
        {
            isRunning = false;
            isWalking = true;

            Invoke("PlayerRun", 0.01f);
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerJump();
        }
    }

    //Draw tool for debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position,groundCheckerRadius);
    }

}
