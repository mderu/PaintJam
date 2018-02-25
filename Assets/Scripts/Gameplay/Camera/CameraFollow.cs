using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;

    public Vector3 offset;
    public float speed;

    void Start()
    {
        player = Player.instance.transform;
    }

    void LateUpdate()
    {
        if (player)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + offset, speed * Time.deltaTime);
        }
    }
}
