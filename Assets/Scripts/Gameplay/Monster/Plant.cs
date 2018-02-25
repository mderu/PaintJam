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
            if (state == State.WaitingToShoot)
            {
                sprite.flipX = player.transform.position.x > transform.position.x;
            }

            if (!doingAction)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    void ChangeState(State newState)
    {
        state = newState;
        anim.SetInteger("State", (int)state);
    }

    IEnumerator Shoot()
    {
        doingAction = true;
        ChangeState(State.WaitingToShoot);
        yield return new WaitForSeconds(timeBeforeShot);
        ChangeState(State.Shooting);
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.GetComponent<EnemyShot>().Shoot(this);
        //yield return new WaitForSeconds(shootDuration);
        //ChangeState(State.Idle);
        yield return new WaitForSeconds(shootCooldown);
        doingAction = false;
    }
}
