using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    Player player;
    ParticleSystem particles;
    public float maxNumParticles;

    void Start()
    {
        player = Player.instance;
        particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float normalizedShine = player.normalizedShine;

        ParticleSystem.MainModule newMain = particles.main;
        Color newColor = newMain.startColor.color;
        newColor.a = normalizedShine;
        newMain.startColor = newColor;

        ParticleSystem.EmissionModule newEmission = particles.emission;
        newEmission.rateOverTime = player.normalizedShine * maxNumParticles;
    }
}
