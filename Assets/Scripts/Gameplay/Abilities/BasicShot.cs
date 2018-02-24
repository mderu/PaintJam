using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Player))]
public class BasicShot : MonoBehaviour
{
    Player player;

    public GameObject projectilePrefab;
    public float length;
    public float duration;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        Vector2 toCursor = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)player.transform.position).normalized;

        Transform projectile = Instantiate(projectilePrefab, player.transform.position, Quaternion.identity).transform;

        Tween myTween = projectile.DOMove((Vector2)player.transform.position + length * toCursor, duration);

        yield return myTween.WaitForCompletion();

        Destroy(projectile.gameObject);
    }
}
