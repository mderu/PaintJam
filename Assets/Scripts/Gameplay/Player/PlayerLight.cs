using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    Light light;
    Player player;
    public float maxRange;
    public float maxIntensity;

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
    }
}
