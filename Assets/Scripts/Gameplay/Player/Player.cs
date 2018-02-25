﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Knockback knockback;

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        knockback = GetComponent<Knockback>();
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

    public void DoDamage(Transform damager, float damage)
    {
        shine -= damage;
        StartCoroutine(DisableMovement());
        knockback.DoKnockback(transform.position - damager.position);
    }

    IEnumerator DisableMovement()
    {
        GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(knockback.duration);
        GetComponent<PlayerMovement>().enabled = true;
    }
}
