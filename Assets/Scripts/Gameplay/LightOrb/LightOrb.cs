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
        // Play the fade out animation.
        GetComponent<Animator>().SetBool("die", true);
        // Wait for the trail particles to fade out before killing the object.
        timeLeft = 1.0f;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            transform.position = magnetizeTo.position;
            yield return 0;
        }
        Destroy(gameObject);
    }
}
