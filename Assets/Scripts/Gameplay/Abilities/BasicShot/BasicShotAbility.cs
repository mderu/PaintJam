﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShotAbility : Ability
{
    public GameObject shotPrefab;

    public override void Activate()
    {
        BasicShot shot = Instantiate(shotPrefab, Player.instance.transform.position, Quaternion.identity).GetComponent<BasicShot>();
        StartCoroutine(shot.Shoot(Player.instance));
    }

    public override void Deactivate()
    {
        
    }
}
