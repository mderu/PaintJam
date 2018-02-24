using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour {

    public float speed;
    //public float stoppingDistance;
    public float timeBeforeJump;

    [HideInInspector]
    public bool playerInRange;
    private bool doingAction;

    public float length;
    private Player player;

    private void Awake()
    {
        playerInRange = false;
        doingAction = false;
    }

    // Use this for initialization
    void Start () {
    
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
        transform.DOMove(transform.position + length * (player.transform.position - transform.position).normalized, speed).OnComplete(()=>SetDoingAction(false)); ;

    }

    private void SetDoingAction(bool var)
    {
        doingAction = var;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void PlayerInRange(Player player)
    {

        playerInRange = true;
        this.player = player;
    
    }
    
    public void PlayerOutRange(Player player)
    {
        playerInRange = false;
        this.player = player;

    }

} // Monster
