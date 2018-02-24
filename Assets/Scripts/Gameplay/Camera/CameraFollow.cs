using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;

    public Vector3 offset;

    void Start()
    {
        player = Player.instance.transform;
    }

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
