using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerAnimations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private StarBoy starBoy;
    private Rigidbody2D rb;
    //Movement Variables
    private float moveSpeed;
    [SerializeField]
    private float speedMultiplier;
    private Vector2 moveDirection;
    private float MAXMOVESPEED = 10f;

    [SerializeField]
    private float fallTimer = 0f;

    //References to additional scripts
    [SerializeField]
    private PlayerStamina playerStamina;

    //Bool conditional variables
    private bool isWalking;
    private bool isRunning;
    private bool isHalting;

    [SerializeField]
    private bool hasLanded;
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
        rb = GetComponent<Rigidbody2D>();
        isWalking = true;
    }

    private void FixedUpdate()
    {
        if (starBoy.isActive)
        {
            rb.AddForce(moveDirection.x * moveSpeed * Vector2.right * speedMultiplier, ForceMode2D.Force);
            Friction();
            PlayerFalling();
            //Ground detection logic
            if (OnGround())
            {
                isGrounded = true;
                canJump = true;
                fallTimer = 0f;
            }
            else
            {
                isGrounded = false;
                canJump = false;
            }
        }
    }
    private void SpeedController()
    {
        const float acceleration = 70.5f;
        const float deceleration = 70.5f;

        if (Mathf.Abs(moveDirection.x) > 0f)
        {

            if (isWalking)
            {
                moveSpeed += Time.deltaTime * acceleration * speedMultiplier;
                if (moveSpeed > starBoy.walkSpeed)
                {
                    moveSpeed = starBoy.walkSpeed;
                }
            }

            if (isRunning)
            {
                moveSpeed += Time.deltaTime * acceleration * speedMultiplier * 2f;
                if (moveSpeed > starBoy.runSpeed)
                {
                    moveSpeed = starBoy.runSpeed;
                }
            }
        }

        if (Mathf.Abs(moveDirection.x) == 0f)
        {
            moveSpeed -= Time.deltaTime * deceleration * speedMultiplier;

            if (moveSpeed <= 0f)
            {
                moveSpeed = 0f;
            }
        }
    }

    private void Update()
    {
        SpeedController();
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

    public bool Halting()
    {
        return isHalting;
    }

    public bool Landed()
    {
        return hasLanded;
    }

    public bool AbleToJump()
    {
        return canJump;
    }

    public Rigidbody2D getRigidbody2D()
    {
        return rb;
    }

    public void setMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public Vector2 getMoveDirection()
    {
        return moveDirection;
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

    private void PlayerJump()
    {
        if (starBoy.isActive)
        {
            if (canJump)
            {
                Vector2 jumpDirection = new Vector2(rb.linearVelocityX, starBoy.jumpForce);
                rb.AddForce(jumpDirection, ForceMode2D.Impulse);
            }
            else return;
        }
        else return;
    }

    public float getFallTime()
    {
        return fallTimer;
    }

    public void PlayerFallingTimer()
    {
        fallTimer += Time.deltaTime;
    }

    private void PlayerFalling()
    {
        if (rb.linearVelocityY < -0.1f)
        {
            Invoke("PlayerFallingTimer", 0.01f);
        }

        if (isGrounded && Mathf.Abs(fallTimer) > 0.1f)
        {
            hasLanded = true;
        }

        if(fallTimer == 0f)
        {
            hasLanded = false;
        }
    }

    public void ResetFallTimer()
    {
        hasLanded = false;
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
        if (context.performed && starBoy.isActive)
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
