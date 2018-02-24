﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection: MonoBehaviour
{

    public Monster member;

    private float radius;

    // Use this for initialization
    void Start()
    {
        radius = transform.GetComponent<CircleCollider2D>().radius;
        //if (gameObject.layer == LayerMask.GetMask("Player"))
        //{
        //    member.playerInRange =
        //    Physics2D.OverlapCircle(transform.position, radius,
        //        LayerMask.GetMask("Player")) != null;
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer == LayerMask.GetMask("Player"))
        {
            member.PlayerInRange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(gameObject.layer == LayerMask.GetMask("Player"))
        {
            member.PlayerOutRange();
        }
    }

}
