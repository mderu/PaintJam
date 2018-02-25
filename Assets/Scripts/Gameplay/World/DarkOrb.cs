using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DarkOrb : MonoBehaviour
{
    public float speed;

    void Start()
    {
        StartCoroutine(GoToGreenFrog());
    }

    IEnumerator GoToGreenFrog()
    {
        GameObject greenFrog = GameObject.FindGameObjectWithTag("GreenFrog");

        yield return new WaitForSeconds(2f);

        Tween myTween = transform.DOMove(greenFrog.transform.position, speed).SetSpeedBased(true);

        yield return myTween.WaitForCompletion();

        Destroy(gameObject);
    }

}
