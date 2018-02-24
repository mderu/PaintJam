using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public Vector3 offset;
    public float lifetime;

    void Start()
    {
        transform.position += offset;
        Destroy(gameObject, lifetime);
    }
}
