using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicShot : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rigidBody;

    public GameObject hitEffectPrefab;
    public int damage;
    public float length;
    public float duration;
    [Range(0f, 1f)]
    public float fadeStart;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        StartCoroutine(DoShoot());
    }

    public IEnumerator DoShoot()
    {
        Transform player = Player.instance.transform;

        Vector2 toCursor = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)player.position).normalized;

        transform.SetPositionAndRotation(player.position, Quaternion.LookRotation(Vector3.forward, toCursor));

        Tween myTween = transform.DOMove((Vector2)player.position + length * toCursor, duration);

        yield return myTween.WaitForStart();

        while (myTween.IsActive())
        {
            if (myTween.ElapsedPercentage() > fadeStart)
            {
                Color newColor = sprite.color;
                newColor.a = Mathf.Lerp(1f, 0f, (myTween.ElapsedPercentage() - fadeStart) / (1 - fadeStart));
                sprite.color = newColor;
            }
            yield return null;
        }

        //yield return myTween.WaitForCompletion();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && collision.gameObject.GetComponent<Monster>())
        {
            collision.gameObject.GetComponent<Monster>().DoDamage(transform, damage);
            Instantiate(hitEffectPrefab, transform.position, Quaternion.LookRotation(collision.transform.position - Player.instance.transform.position));
            Destroy(gameObject);
        }
    }
}
