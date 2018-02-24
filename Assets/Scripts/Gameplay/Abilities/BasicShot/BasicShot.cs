using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicShot : MonoBehaviour
{
    SpriteRenderer sprite;

    public GameObject hitEffectPrefab;
    public int damage;
    public float length;
    public float duration;
    [Range(0f, 1f)]
    public float fadeStart;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Shoot(Player player)
    {
        StartCoroutine(DoShoot(player));
    }

    public IEnumerator DoShoot(Player player)
    {
        Vector2 toCursor = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)player.transform.position).normalized;

        transform.SetPositionAndRotation(player.transform.position, Quaternion.LookRotation(Vector3.forward, toCursor));

        Tween myTween = transform.DOMove((Vector2)player.transform.position + length * toCursor, duration);

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.GetComponent<Monster>().DoDamage(damage);
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
