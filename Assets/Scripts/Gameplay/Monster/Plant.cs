using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Monster
{
    enum State { Idle, WaitingToShoot, Shooting }
    State state = State.Idle;

    public GameObject projectilePrefab;
    public float shootCooldown;
    public float shootDuration;
    public float timeBeforeShot;

    protected override void Start()
    {
        base.Start();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerInRange)
        {
            Debug.Log("Player in range");
            if (state == State.WaitingToShoot)
            {
                sprite.flipX = player.transform.position.x > transform.position.x;
            }
            if (!doingAction)
            {
                Debug.Log("Firing");
                doingAction = true;
                ChangeState(State.WaitingToShoot);
                GetComponent<Animator>().SetTrigger("attack");
            }
        }
    }

    void ChangeState(State newState)
    {
        state = newState;
    }

    void Shoot()
    {
        StartCoroutine(ShootSequence());
    }

    IEnumerator ShootSequence()
    {
        ChangeState(State.Shooting);
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.GetComponent<EnemyShot>().Shoot(this);
        //yield return new WaitForSeconds(shootDuration);
        //ChangeState(State.Idle);
        yield return new WaitForSeconds(shootCooldown);
        doingAction = false;
    }
}
