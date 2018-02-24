using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection: MonoBehaviour
{

    public Monster member;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == LayerMask.GetMask("Player"))
        {
            Debug.Log("[pp[");
            member.PlayerInRange(collision.GetComponent<Player>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(1 << collision.gameObject.layer == LayerMask.GetMask("Player"))
        {
            member.PlayerOutRange(collision.GetComponent<Player>());

        }
    }

}
