using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection: MonoBehaviour
{
    public Monster member;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            member.PlayerInRange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            member.PlayerOutRange();
        }
    }

}
