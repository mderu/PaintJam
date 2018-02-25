using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public int maxHealth;
    protected int currentHealth;

    public int damage;

    [HideInInspector]
    public bool playerInRange;
    protected bool doingAction;
    protected Rigidbody2D rigidBody;

    protected Player player;
    protected Animator anim;
    [SerializeField]
    protected SpriteRenderer sprite;

    public GameObject lightOrbPrefab;

    protected virtual void Start()
    {
        player = Player.instance;
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        playerInRange = false;
        doingAction = false;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public virtual void DoDamage(Transform damager, int damage)
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.gameObject.GetComponent<Player>())
        {
            player.DoDamage(transform, damage);
        }
    }

} // Monster
