using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{

    [SerializeField]
    private StarBoy starBoy;
    private Animator animator;
    private bool isFacingRight;

    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerColor playerColor;

    [SerializeField]
    private ParticleSystem colorShiftBurstParticle;
    [SerializeField]
    private ParticleSystem afterImageBurstParticle;

    ///This represents the color mode the player is in, based on this the player will be able to perform different abilities
    public enum MoveStates
    {
        IDLE,
        WALK,
        RUN,
        HALT,
        JUMP,
        FALL,
        LANDED,
        GRIND
    }

    [Space(10f)]
    public MoveStates state;//idle


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        isFacingRight = true;
    }


    /// <summary>
    /// Flip gets the current local scale and flips it by multiplying it by -1
    /// and setting the value of isFacingRight to the opposite value (true or false)
    /// </summary>

    private void SpriteXDirection()
    {
        if (playerMovement.getMoveDirection().x < -0.01f && isFacingRight)
        {
            Flip();
        }

        if (playerMovement.getMoveDirection().x > 0.01f && !isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentLocalScale = this.transform.localScale;
        currentLocalScale.x *= -1;
        transform.localScale = currentLocalScale;
        isFacingRight = !isFacingRight;
    }

    private void SpriteChangeUpdate()
    {
        //Idle
        if (playerMovement.OnGround())
        {
            if (Mathf.Abs(playerMovement.getMoveDirection().x) == 0f)
            {
                state = MoveStates.IDLE;
            }

            //Walking and Runing

            if (Mathf.Abs(playerMovement.getMoveDirection().x) > 0.1f)
            {
                if (playerMovement.Walking())
                {
                    state = MoveStates.WALK;
                }

                if (playerMovement.Running())
                {
                    state = MoveStates.RUN;
                }
            }

            //Landed

            if (playerMovement.Landed())
            {
                state = MoveStates.LANDED;
                playerMovement.setMoveSpeed(0f);
            }
        }
        else
        {
            if(playerMovement.getRigidbody2D().linearVelocityY > 0.1f)
            {
                state = MoveStates.JUMP;
            }

            if (playerMovement.getRigidbody2D().linearVelocityY < -0.1f)
            {
                state = MoveStates.FALL;
            }
        }
    }

    public void SetMaterialColor()
    {
        StartCoroutine(playerColor.ColorShift());
    }

    IEnumerator burtsParticle()
    {
        afterImageBurstParticle.Play();
        colorShiftBurstParticle.Play();
        yield return new WaitForSeconds(1f);
        colorShiftBurstParticle.Stop();
        yield return new WaitForSeconds(1f);
        afterImageBurstParticle.Stop();
    }
    public void PlayParticle()
    {
        StartCoroutine(burtsParticle());
    } 


    public void EndLandingSequence()
    {
        playerMovement.ResetFallTimer();
        playerMovement.setMoveSpeed(starBoy.walkSpeed);
    }

    private void setAnimationParameters()
    {
        animator.SetInteger("MoveStates", (int)state);
        animator.SetBool("ColorShift", playerColor.getColorShift());
        SpriteChangeUpdate();
    }

    public bool SpriteFacingRight()
    {
        return isFacingRight;   
    }

    public void EndColorShift()
    {
        playerColor.setColorShift(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (starBoy.isActive)
        {
            SpriteXDirection();
            setAnimationParameters();
        }
    }
}
