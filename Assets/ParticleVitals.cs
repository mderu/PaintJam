using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleVitals : MonoBehaviour
{
    [Range(0, 1)]
    public float _health = 1.0f;

    public float health
    {
        get { return _health; }
        set
        {
            _health = value;
            playerLight.intensity = _health;
            //bodyParticles.main.startColor = Color.red;
        }
    }

    [SerializeField]
    private Light playerLight;

    [SerializeField]
    private ParticleSystem bodyParticles;

    [SerializeField]
    private ParticleSystem trailParticles;
}
