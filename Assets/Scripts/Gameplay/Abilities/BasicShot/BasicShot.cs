using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicShot : MonoBehaviour
{
    public int damage;
    public float length;
    public float duration;

    public IEnumerator Shoot(Player player)
    {
        Vector2 toCursor = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)player.transform.position).normalized;

        transform.SetPositionAndRotation(player.transform.position, Quaternion.LookRotation(Vector3.forward, toCursor));

        Tween myTween = transform.DOMove((Vector2)player.transform.position + length * toCursor, duration);

        yield return myTween.WaitForCompletion();

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.GetComponent<Monster>().DoDamage(damage);
        }
    }
}
