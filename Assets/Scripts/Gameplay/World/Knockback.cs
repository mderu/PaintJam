using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour
{
    public float force;
    public float duration;

    bool isKnockingback = false;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void DoKnockback(Vector2 direction)
    {
        //rigidBody.AddForce(force * direction.normalized, ForceMode2D.Impulse);
        if (isKnockingback) return;

        StartCoroutine(Tween(direction));
    }

    IEnumerator Tween(Vector2 direction)
    {
        isKnockingback = true;

        Tween tween = rigidBody.DOMove((Vector2)transform.position + force * direction.normalized, duration);

        yield return tween.WaitForCompletion();

        isKnockingback = false;
    }
}
