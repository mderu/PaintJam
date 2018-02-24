﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public int maxHealth;
    protected int currentHealth;

    public int damage;

    public float speed;

    [HideInInspector]
    public bool playerInRange;
    protected bool doingAction;

    protected Player player;

    public GameObject lightOrbPrefab;

    private void Awake()
    {
        currentHealth = maxHealth;
        playerInRange = false;
        doingAction = false;
    }

    void Start()
    {
        player = Player.instance;
    }

    public virtual void DoDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // TODO: do die stuff
        Instantiate(lightOrbPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void PlayerInRange()
    {
        playerInRange = true;
    }
    
    public void PlayerOutRange()
    {
        playerInRange = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.DoDamage(damage);
        }
    }

} // Monster
