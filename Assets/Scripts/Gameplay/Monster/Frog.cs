using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Frog : Monster
{
    enum State { Idle, WaitingToLunge, Lunging }

    Knockback knockback;
    Tween lungeTween;

    //public float stoppingDistance;
    public float lungeCooldown;
    public float timeBeforeJump;
    public float lungeDuration;
    public float length;

    public AnimationCurve easeCurve;

    State state = State.Idle;

    protected override void Start()
    {
        base.Start();
        knockback = GetComponent<Knockback>();
    }

    void Update()
    {
        if (playerInRange)
        {
            if (state == State.WaitingToLunge)
            {
                sprite.flipX = player.transform.position.x > transform.position.x;
            }

            if (!doingAction)
            {
                StartCoroutine(DoLunge());
            }
        }
    }

    public override void DoDamage(Transform damager, int damage)
    {
        base.DoDamage(damager, damage);
        if (lungeTween != null)
        {
            lungeTween.Kill();
        }
        knockback.DoKnockback(GetComponentInChildren<MonsterDamager>().transform.position - damager.position);
    }

    void ChangeState(State newState)
    {
        state = newState;
        anim.SetInteger("State", (int)newState);
    }

    IEnumerator DoLunge()
    {
        doingAction = true;
        ChangeState(State.WaitingToLunge);
        yield return new WaitForSeconds(timeBeforeJump);
        lungeTween = rigidBody.DOMove(transform.position + length * (player.transform.position - transform.position).normalized, lungeDuration);
        lungeTween.SetEase(easeCurve);
        ChangeState(State.Lunging);
        yield return lungeTween.WaitForCompletion();
        lungeTween = null;
        ChangeState(State.Idle);
        yield return new WaitForSeconds(lungeCooldown);
        doingAction = false;
    }
}
