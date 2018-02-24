using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    public float maxShine = 100f;
    public float minNormalizedShine;

    [SerializeField, Range(0f, 100f)]
    float _shine = 10f;
    public float shine
    {
        get { return _shine; }

        set
        {
            if (value <= 0)
            {
                Die();
            }
            _shine = Mathf.Clamp(value, 0, maxShine);
        }
    }

    public float normalizedShine
    {
        get
        {
            return Mathf.Clamp(_shine / maxShine, minNormalizedShine, 1f);
        }
    }

    void Die()
    {
        // TODO : do die stuff
        Destroy(gameObject);
    }

    public void DoDamage(float damage)
    {
        shine -= damage;
    }
}
