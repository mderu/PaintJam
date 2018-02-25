using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamager : MonoBehaviour
{
    public Monster monster;

    void Start()
    {
        if (!monster && GetComponent<Monster>())
        {
            monster = GetComponent<Monster>();
        }
    }

    public void DoDamage(Transform damager, int damage)
    {
        if (!monster) return;
        monster.DoDamage(damager, damage);
    }
}
