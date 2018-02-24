using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    Ability ability0;
    Ability ability1;

    void Start()
    {
        ability0 = GetComponent<BasicShotAbility>();
    }

    void Update()
    {
        if (ability0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ability0.Activate();
            }
            if (Input.GetMouseButtonUp(0))
            {
                ability0.Deactivate();
            }
        }
        if (ability1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ability1.Activate();
            }
            if (Input.GetMouseButtonUp(1))
            {
                ability1.Deactivate();
            }
        }
    }
}
