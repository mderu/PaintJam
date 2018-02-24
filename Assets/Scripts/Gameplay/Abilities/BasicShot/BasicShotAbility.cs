﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShotAbility : Ability
{
    public GameObject shotPrefab;

    public override void Activate()
    {
        if (canActivate)
        {
            BasicShot shot = Instantiate(shotPrefab).GetComponent<BasicShot>();
            StartCoroutine(shot.Shoot(Player.instance));
            StartCoroutine(Cooldown());
        }
    }

    public override void Deactivate()
    {
        
    }
}
