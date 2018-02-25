using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {



    [HideInInspector]
    protected Rigidbody2D rigidBody;
    
    protected Animator anim;
    [SerializeField]
    protected SpriteRenderer sprite;

    public GameObject enemy;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }



    public virtual void Die()
    {
        // TODO: do die stuff


        //Change to green frog fade
        Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
