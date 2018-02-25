using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public GameObject enemy;

    public virtual void Die()
    {
        // TODO: do die stuff


        //Change to green frog fade
        Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DarkOrb")
        {
            StartCoroutine(DieDelayed());
        }
    }

    IEnumerator DieDelayed()
    {
        yield return new WaitForSeconds(2f);

        Die();
    }
}
