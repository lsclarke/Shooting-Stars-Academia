using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackController : MonoBehaviour, IKnockBackable
{
    [Header("-----Knock Back Effect Settings-----")]
    [Space(10)]

    [SerializeField] private Rigidbody2D physics;
    [SerializeField] public float strength;
    [SerializeField] public float duration;
    [HideInInspector] public bool isKnockedBack;
    [HideInInspector] public bool enemyIsKnockedBack;

    [Header("-----Reference/Call on these Scripts-----")]
    [Space(10)]
    public PlayerMovement movement;

    public void PlayKnockBack(GameObject other)
    {
        StopAllCoroutines();
        isKnockedBack = true;
        movement.enabled = false;

        Vector2 direction = (transform.position - other.transform.position).normalized;
        print("Direction: " + direction);
        physics.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(StopKnockBack(duration));
    }

    public void PlayEnemyKnockBack(GameObject other)
    {
        enemyIsKnockedBack = true;

        Vector2 direction = (transform.position - other.transform.position).normalized;
        direction.y *= 1.5f;
        print("Direction: " + direction);
        physics.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(StopEnemyKnockBack(duration));
    }

    public IEnumerator StopEnemyKnockBack(float time)
    {
        yield return new WaitForSeconds(time);
        enemyIsKnockedBack = false;
        physics.linearVelocity = Vector3.zero;
    }

    public IEnumerator StopKnockBack(float time)
    {
        yield return new WaitForSeconds(time);
        isKnockedBack = false;
        movement.enabled = true;

        physics.linearVelocity = Vector3.zero;
    }
}
