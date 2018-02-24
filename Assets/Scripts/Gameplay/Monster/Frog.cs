using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Frog : Monster
{
    //public float stoppingDistance;
    public float timeBeforeJump;

    public float length;

    void Update()
    {
        if (playerInRange && !doingAction)
        {
            Lunge();
        }
    }

    public void Lunge()
    {
        StartCoroutine(DoLunge());
    }

    public IEnumerator DoLunge()
    {
        doingAction = true;
        yield return new WaitForSeconds(timeBeforeJump);
        Tween myTween = transform.DOMove(transform.position + length * (player.transform.position - transform.position).normalized, speed);

        yield return myTween.WaitForCompletion();

        doingAction = false;

    }
}
