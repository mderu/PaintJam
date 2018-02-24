﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour {

    public float speed;
    //public float stoppingDistance;
    private Rigidbody2D myBody;
    public float timeBeforeJump;

    public Transform target;
    public Transform myTransform;

    [HideInInspector]
    public bool playerInRange;
    private bool doingAction;

    public float length;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerInRange = true;
        doingAction = false;
    }

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    
	}
	
	// Update is called once per frame
	void Update () {
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
        SetDoingAction(true);
        yield return new WaitForSeconds(timeBeforeJump);
        transform.DOMove(myTransform.position + length * (target.position - myTransform.position).normalized, speed).OnComplete(()=>SetDoingAction(false)); ;

    }

    private void SetDoingAction(bool var)
    {
        doingAction = var;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void PlayerInRange()
    {
        playerInRange = true;
    }
    
    public void PlayerOutRange()
    {
        playerInRange = false;
    }

} // Monster