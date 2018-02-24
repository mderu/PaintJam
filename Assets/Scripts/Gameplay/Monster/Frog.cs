﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Frog : Monster
{
    enum State { Idle, WaitingToLunge, Lunging }

    //public float stoppingDistance;
    public float lungeCooldown;
    public float timeBeforeJump;
    public float lungeDuration;
    public float length;

    public AnimationCurve easeCurve;

    State state = State.Idle;

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
                Lunge();
            }
        }
    }

    public void Lunge()
    {
        StartCoroutine(DoLunge());
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
        Tween myTween = transform.DOMove(transform.position + length * (player.transform.position - transform.position).normalized, lungeDuration);
        myTween.SetEase(easeCurve);
        ChangeState(State.Lunging);
        yield return myTween.WaitForCompletion();
        ChangeState(State.Idle);
        yield return new WaitForSeconds(lungeCooldown);
        doingAction = false;
    }
}
