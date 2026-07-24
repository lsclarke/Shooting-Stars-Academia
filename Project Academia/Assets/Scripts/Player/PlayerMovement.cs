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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = starBoy.walkSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection);
        Friction();
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

    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>() * moveSpeed;
    }
    public void Run(InputAction.CallbackContext context)
    {
        
    }
    public void Jump(InputAction.CallbackContext context)
    {
        
    }

}
