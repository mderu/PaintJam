using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyShot : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rigidBody;

    public GameObject hitEffectPrefab;
    int damage;
    public float length;
    public float duration;
    [Range(0f, 1f)]
    public float fadeStart;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Monster monster)
    {
        damage = monster.damage;
        StartCoroutine(DoShoot(monster));
    }

    public IEnumerator DoShoot(Monster monster)
    {
        if (!Player.instance) { yield break; }
        Transform player = Player.instance.transform;
        Transform monsterTransform = monster.transform;

        Vector2 toPlayer = (player.position - monsterTransform.position).normalized;

        transform.SetPositionAndRotation(monsterTransform.position, Quaternion.LookRotation(Vector3.forward, toPlayer));

        Tween myTween = rigidBody.DOMove((Vector2)monsterTransform.position + length * toPlayer, duration);
 
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().DoDamage(transform, damage);
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
