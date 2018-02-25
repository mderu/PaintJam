using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShotAbility : Ability
{
    public GameObject shotPrefab;
    public int shotCost;

    public override void Activate()
    {
        if (canActivate)
        {
            BasicShot shot = Instantiate(shotPrefab).GetComponent<BasicShot>();
            shot.Shoot();
            GetComponent<Player>().shine -= shotCost;
            StartCoroutine(Cooldown());
        }
    }

    public override void Deactivate()
    {
        
    }
}
