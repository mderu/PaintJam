using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public abstract void Activate();
    public abstract void Deactivate();

    public float cooldown;
    protected bool canActivate = true;

    protected IEnumerator Cooldown()
    {
        canActivate = false;
        yield return new WaitForSeconds(cooldown);
        canActivate = true;
    }
}
