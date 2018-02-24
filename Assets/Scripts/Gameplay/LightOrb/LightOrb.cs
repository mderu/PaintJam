using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrb : MonoBehaviour
{
    public float shine;

    private Transform magnetizeTo;
    private Vector3 startLocation;
    private float timeLeft = 1.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<Player>().shine += shine;
            GetComponent<Collider2D>().enabled = false;
            magnetizeTo = collision.transform;
            StartCoroutine(Magnetize());
        }
    }

    IEnumerator Magnetize()
    {
        startLocation = transform.position;
        while(timeLeft > 0)
        {
            transform.position = Vector3.Lerp(startLocation, magnetizeTo.position, 1 - timeLeft * timeLeft);
            timeLeft -= Time.deltaTime;
            yield return 0;
        }
        timeLeft = 1.0f;
        // Disable the LightOrb's sprite renderer.
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        // Disable Sparkle emission
        ParticleSystem.EmissionModule em = transform.GetChild(1).GetComponent<ParticleSystem>().emission;
        em.enabled = false;
        // Wait for the trail particles to stop before killing the object.
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return 0;
        }
        Destroy(gameObject);
    }
}
