using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    Light light;
    Player player;
    public float maxRange;
    public float maxIntensity;
    public float minHeight;
    public float maxHeight;

    void Start()
    {
        light = GetComponent<Light>();
        player = Player.instance;
    }

    void Update()
    {
        float normalizedShine = player.normalizedShine;
        light.intensity = normalizedShine * maxIntensity;
        light.range = normalizedShine * maxRange;
        Vector3 newPosition = transform.position;
        newPosition.z = minHeight + normalizedShine * (maxHeight - minHeight);
        transform.position = newPosition;
    }
}
