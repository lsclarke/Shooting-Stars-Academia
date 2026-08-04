using System.Collections;
using UnityEngine;

public class PlayerHealth : KnockBackController
{

    [SerializeField]
    private StarBoy starBoy;
    public GameOverCanvasController gameOverCanvasController;
    private float timeScale = 0.001f;
    private float pauseTime = 0.0001f;
    private CameraShake cameraShake;
    public SpriteRenderer playerSpriteRenderer;
    private const float MAXHEALTH = 100f;

    private bool isHurt;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        starBoy.health = MAXHEALTH;
        isHurt = false;

        cameraShake = GameObject.Find("Camera Shaker").gameObject.GetComponent<CameraShake>();
    }
    
    public float getMaxHealth()
    {
        return MAXHEALTH;
    }

    public void setIsHurt(bool value)
    {
        isHurt = value;
    }

    public bool getIsHurt(bool value)
    {
        return isHurt;
    }

    IEnumerator resetCondition()
    {
        playerSpriteRenderer.material.SetInt("_Flash", 1);
        yield return new WaitForSeconds(.15f);
        playerSpriteRenderer.material.SetInt("_Flash", 0);
        yield return new WaitForSeconds(.25f);
        playerSpriteRenderer.material.SetInt("_Flash", 1);
        yield return new WaitForSeconds(.05f);
        playerSpriteRenderer.material.SetInt("_Flash", 0);
        isHurt = false;
    }

    public void OnTakeDamage(float value)
    {
        starBoy.health -= value;

        isHurt = true;
        StartCoroutine(resetCondition());

        if (starBoy.health <= 0)
        {
            gameOverCanvasController.ActivateGameOverScreen();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayKnockBack(other.gameObject);
            OnTakeDamage(15);

            StartCoroutine(HitStop(pauseTime));
            StartCoroutine(cameraShake.Shake(cameraShake.shakeTime, cameraShake.shakeSpeed));
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            PlayKnockBack(other.gameObject);
            OnTakeDamage(5);
            StartCoroutine(HitStop(pauseTime));
            StartCoroutine(cameraShake.Shake(cameraShake.shakeTime, cameraShake.shakeSpeed));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            if (!isHurt)
            {
                PlayKnockBack(other.gameObject);
                OnTakeDamage(5);
                StartCoroutine(HitStop(pauseTime));
                StartCoroutine(cameraShake.Shake(cameraShake.shakeTime, cameraShake.shakeSpeed));
            }
        }
    }

    public IEnumerator HitStop(float duration)
    {
        Time.timeScale = timeScale;
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1f;

    }
}
